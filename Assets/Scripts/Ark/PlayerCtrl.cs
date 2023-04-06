using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Core.Character;
using Core;
using ArkSkill.Core;
using Core.UI;
using Baracuda.Monitoring;

public delegate BeAttackedable[] GetTargets(Transform transform);

public class PlayerCtrl :MonitoredBehaviour/*MonoBehaviour*/
{
    PlayerController moveCtrl;
    SkillManager skillManager;
    Animator animator;
    Rigidbody2D rigidbody2D;
    [Header("Attack Particle")]
    public ParticleSystem particle;

    [SerializeField] PlayerData playerData;

    string PlayerHpUI(int currentHp)
    {
        var sb = new System.Text.StringBuilder();
        sb.Append("Hp: ");
        sb.Append(currentHp.ToString("00"));
        sb.Append('/');
        sb.Append(MaxHp.ToString("00"));
        sb.Append(' ');

        var color =new Color(.25f, .25f, .3f);
        sb.Append('▐', currentHp);
        sb.Append("<color=#");
        sb.Append(ColorUtility.ToHtmlStringRGB(color));
        sb.Append('>');
        sb.Append('▐', MaxHp - currentHp);
        sb.Append("</color>");

        return sb.ToString();
    }

    #region Monitor
    //[MonitorProperty]
    //[MFontSize(16)]
    //[MGroupElement(false)]
    //[MPosition(UIPosition.UpperLeft)]
    //[MFontName("JetBrainsMono-Regular")]
    //[MTextColor(ColorPreset.Red)]
    //[MValueProcessor(nameof(PlayerHpUI))]
    #endregion
    public int Hp
    {
        get => playerData.HP;
        set {
            if (value < 0) playerData.HP = 0;
            else if (value > MaxHp) playerData.HP = MaxHp;
            else playerData.HP = value;
        }
    }
    /*[Monitor]*/public int Energe
    {
        get => playerData.Energe;
        set {
            if (value < 0) playerData.Energe = 0;
            else if (value > MaxEnerge) playerData.Energe = MaxEnerge;
            else playerData.Energe = value;
        }
    }
    public int MaxHp { get => playerData.MaxHp; private set => playerData.MaxHp = value; }
    public int MaxEnerge { get => playerData.MaxEnerge; private set => playerData.MaxEnerge = value; }
    public float AttackPower { get => playerData.AttackPower; private set => playerData.AttackPower = value; }
    public float pushPower = 1f;
    [Header("Sub CD")]
    public float SubTime = 30f;//触发减CD时减少的时间
    int lastSkillID=-1;//上一个命中的技能ID
    //暂时使用中心事件队列实现
    void TriggerSub(int id)
    {
        if (id == 11) Hp+=2;//TODO:ID视化
        if (lastSkillID == id) return;//技能相同 直接返回
        //触发减CD
        foreach(var elem in m_runtimeSkillCfg.RSkillCfgMap)
        {
            if (elem.Key == id) continue;//若命中技能为释放技能，则跳过
            if (elem.Value.LastCdTime > 0) elem.Value.LastCdTime -= SubTime;//若CD大于零，则减少CD
        }
        lastSkillID = id;//更新上一次命中技能ID
    }
    /// <summary>
    /// 设置是否禁用移动模块
    /// </summary>
    public bool EnableMoveCtrl { set { moveCtrl.Controllable = value; } }
    public bool EnableJump { set { moveCtrl.Jumpable = value; } }
    protected override void Awake()
    {
        base.Awake();
        skillManager = GetComponent<SkillManager>();
        moveCtrl = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        //Camera
        cam = Camera.main;
        camController = cam.GetComponent<CameraController>();
        //Skill
        moveCtrl.OnLanded += ResetUpswing;//增加监听
        TQueueExtion.OnSkillHurt += TriggerSub;//增加监听
    }
    //重置上挑
    private void ResetUpswing()
    {
        useable = true;//重置上挑
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        moveCtrl.OnLanded -= ResetUpswing;//移除监听
        TQueueExtion.OnSkillHurt -= TriggerSub;//移除监听
    }
    private void FixedUpdate()
    {
        if(moveCtrl.isOnGround==true&&useableDash==false)//在地面上且冲刺未重置
        {
            useableDash = true;//重置冲刺
        }
    }
    private void Update()
    {
        
        m_runtimeSkillCfg.SubCD(Time.deltaTime);//调用减CD
        //if (!CanBeHit) return;//受伤无敌状态 直接返回
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;//有UI打开，直接返回
        if (skillManager.currSkill == null)
        {
            if (Input.GetKey(InputManager.Instance.inputSystemDic["attackKey"])) skillManager.UseSkill(0);
            if (Input.GetKeyDown(InputManager.Instance.inputSystemDic["dashKey"])) Dash();
            //if (Input.GetButtonDown("Replay")) RePlay();
            //if (Input.GetButtonDown("Storage")) skillManager.UseSkill(3);
            //if (Input.GetButtonDown("Cure") && Energe > 0 && moveCtrl.isOnGround) skillManager.UseSkill(4);
            //if (Input.GetButtonDown("Shield") && Energe > 2 && moveCtrl.isOnGround) { skillManager.UseSkill(5); }
            if (Input.GetKeyDown(InputManager.Instance.inputSystemDic["upswingKey"])) Upswing();
            if (Input.GetKeyDown(InputManager.Instance.inputSystemDic["cycloneKey"]) && !moveCtrl.isOnGround) Cyclone();
            if (Input.GetKeyDown(InputManager.Instance.inputSystemDic["subductionKey"]) && !moveCtrl.isOnGround) skillManager.UseSkill(8);
            //if (Input.GetKeyDown(KeyCode.Q)) skillManager.UseSkill(9);
            //if (Input.GetKeyDown(KeyCode.H)) NewCure();
            if(Input.GetKeyDown(InputManager.Instance.inputSystemDic["substituteKey"])) skillManager.UseSkill(10);
            if (Input.GetKeyDown(InputManager.Instance.inputSystemDic["chopKey"])) Chop();
        }
        //if (Input.GetButtonUp("Storage")) skillManager.StopSkill(3);
        //if (Input.GetButtonUp("Cure") || Energe <= 0) skillManager.StopSkill(4);
        //if (Input.GetButtonUp("Shield")) skillManager.StopSkill(5);
        //if (Input.GetKeyUp(KeyCode.X)) InputHandler.Instance.jumpKey = KeyCode.L;//skillManager.StopSkill(9);

    }

    #region DestoryChild
    public event Action<UnityEngine.Object, float> onChildDestory;
    public void DestoryChild(UnityEngine.Object obj, float durTime)
    {
        onChildDestory.Invoke(obj, durTime);
    }
    #endregion

    #region PlayAttackParticle
    public event Action<Vector3, float> onPlarticleEnd;
    public void PlayAttackParticle(Vector3 offset, float partScale)
    {
        if (particle == null) return;
        //TODO:特效单例
        var effect = Instantiate(particle, transform);//将特效设置为子物体
        Transform effectTransform = effect.transform;
        effectTransform.localPosition = offset;//偏移
        effectTransform.localScale *= partScale;//特效尺寸倍数
        effect?.Play();

        //持续时间结束后销毁
        var duration = effect.main.duration + effect.main.startLifetime.constantMax;
        effect.gameObject.AddComponent<Core.Util.Disposable>().lifetime = duration;
        StartCoroutine(TQueueExtion.DelayFunc(onPlarticleEnd, offset, partScale, effect.main.startLifetime.constantMax));//设置结束点
    }
    #endregion

    #region New Cure
    [SerializeField] RuntimeSkillCfg m_runtimeSkillCfg;
    [SerializeField] int m_skillId;
    void NewCure()
    {
#if UNITY_EDITOR
        if (!m_runtimeSkillCfg.RSkillCfgMap.ContainsKey(m_skillId)) { Debug.Log("尚未获得此技能"); return; }
        var skillCfg = m_runtimeSkillCfg.RSkillCfgMap[m_skillId];
        if (skillCfg.LastCdTime <= 0)//冷却时间为零
        {
            Hp += 1;//用skillManager调用技能
            skillCfg.LastCdTime = skillCfg.CdTime;//重新进入CD
        }
#endif
    }
    #endregion

    #region Chop
    void Chop()
    {
        if (!m_runtimeSkillCfg.RSkillCfgMap.ContainsKey(11)) { Debug.Log("尚未获得此技能"); return; }
        var skillCfg = m_runtimeSkillCfg.RSkillCfgMap[11];
        if (skillCfg.LastCdTime <= 0)//冷却时间为零
        {
            skillManager.UseSkill(11);//用skillManager调用技能
            skillCfg.LastCdTime = skillCfg.CdTime;//重新进入CD
        }
    }
    #endregion

    #region Upswing
    [SerializeField] int upswingId;
    [SerializeField] bool useable=true;//是否可用
    void Upswing()//上挑
    {
        if (!m_runtimeSkillCfg.RSkillCfgMap.ContainsKey(upswingId)) { Debug.Log("尚未获得此技能"); return; }
        if (!useable) { Debug.Log("未重置"); return; }
        skillManager.UseSkill(6);//用skillManager调用技能
        useable = false;//关闭
    }
    #endregion

    #region Cyclone
    void Cyclone()
    {
        if (!m_runtimeSkillCfg.RSkillCfgMap.ContainsKey(7)) { Debug.Log("尚未获得此技能"); return; }
        var skillCfg = m_runtimeSkillCfg.RSkillCfgMap[7];
        if (skillCfg.LastCdTime <= 0)//冷却时间为零
        {
            skillManager.UseSkill(7);//用skillManager调用技能
            skillCfg.LastCdTime = skillCfg.CdTime;//重新进入CD
        }
    }
    #endregion

    #region Attack
    public event Action<Return<float>, GetTargets> onAttack;
    /// <summary>
    /// 攻击函数
    /// </summary>
    /// <param name="caculateDamage">计算伤害委托</param>
    /// <param name="getTargets">获取目标委托</param>
    public void Attack(Return<float> caculateDamage, GetTargets getTargets)
    {
        float damage = caculateDamage == null ? AttackPower : caculateDamage();//计算伤害
        foreach (var target in getTargets?.Invoke(transform))
        {
            target?.OnAttackHit(transform.position, new Vector2(moveCtrl.facingDirection, 0) * pushPower, damage);
            if (target.gameObject.layer == 10)
            {
                if (target.marked)
                {
                    m_runtimeSkillCfg.SubCD(180f);//额外冷却减免
                    target.RemoveModifier();//移除标记
                }
                Energe++;//每命中一个敌人增加一点能量
                TriggerSub(0);//触发-CD
            }
        }
        onAttack?.Invoke(caculateDamage, getTargets);
    }
    #endregion

    #region Dash
    private const float dashCd = 0.4f;//cd
    public float DashCd { get => dashCd; }
    private float lastUse_dash = -dashCd;//上次使用的时间
    public float LastUse_dash => lastUse_dash;
    [SerializeField] bool useableDash = true;//是否可用
    //按下Dash后调用此函数
    void Dash()
    {
        if (!useableDash) { Debug.Log("未重置"); return; }
        //TODO: 处理cd时间与同一时间内其他技能使用冲突
        if (Time.realtimeSinceStartup - lastUse_dash > dashCd)//若现在时间-上次使用时间>cd时间
        {
            skillManager.UseSkill(1);//使用技能
            lastUse_dash = Time.realtimeSinceStartup;//刷新上次使用时间
            useableDash = false;//关闭
        }
    }
    #endregion

#if UNITY_EDITOR
    #region RePlay
    private const float rePlayCd = 3f;//cd
    private float lastUse_RePlay = -rePlayCd;//上次使用的时间
    //按下Dash后调用此函数
    void RePlay()
    {
        if (Time.realtimeSinceStartup - lastUse_RePlay > rePlayCd)//若现在时间-上次使用时间>cd时间
        {
            skillManager.UseSkill(2);//使用技能
            lastUse_RePlay = Time.realtimeSinceStartup;//刷新上次使用时间
        }
    }
    #endregion

#endif

    #region Hurt and Die also Camera and 替身
    // Hit Protection(受击无敌)
    public GameObject hurtFlashObject;
    [Monitor]
    private bool isDying;

    [SerializeField] float hitProtectionDuration = 1.0f;
    [SerializeField] SharedCounter<bool> canBeHit = new SharedCounter<bool>(true, () => { return false; }, (ref bool bert) => { bert = true; });
    [Monitor] public bool CanBeHit {get{ return canBeHit.GetRef(); }
        set 
        {
            if (!value) canBeHit.Increase();
            else canBeHit.Decrease();
        }
    }
    [SerializeField] bool substitute = false;
    [SerializeField] float distance=3f;//瞬移距离
    [SerializeField] LayerMask Impenetrable;//瞬移不可穿透的层
    [SerializeField] Vector3 offset;
    [SerializeField] float ImpOffset=0.2f;//遇到不可穿透层的偏移
    [Monitor]
    public bool Substitute//替身术状态
    {
        get => substitute;
        set
        {
            substitute = value;
            if (substitute) //添加时
            {
                OnHurt += SubstituteInvoke;//添加对受击事件监听
            }
            else//移除时
            {
                OnHurt -= SubstituteInvoke;//移除对受击事件监听
            }
        }
    }
    bool SubstituteInvoke()//替身术触发函数，在替身术状态持续期间若受攻击则调用
    {
        Substitute = false;//移除自身
        skillManager.Interrupt();//中断技能（移除完全静止）
        CanBeHit = false;//进入无敌状态
        StartCoroutine(TQueueExtion.DelayFunc(() => { CanBeHit = true; }, 0.4f));//持续时间后移除
        //获取方向向量
        float hor = InputManager.GetAxisRaw("Horizontal");
        float ver = InputManager.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(hor, ver);//获取方向向量
        if (!Input.GetKey(InputManager.Instance.inputSystemDic["substituteKey"])) dir = Vector2.zero;//若没有按下替身术键，则不瞬移
        //射线检测目标方向-->瞬移距离=Min(distance,Line)
        Debug.Log(dir);//看看方向
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position + offset, dir, distance, Impenetrable);
        float trueDis = distance;//真正瞬移距离
        if (hitInfo.collider != null)//该方向上有地形阻挡
        {
            trueDis = Vector2.Distance(transform.position + offset, hitInfo.point);//真正瞬移距离为当前位置到地形的距离
        }
        transform.position = transform.position + (Vector3)dir.normalized * trueDis;//瞬移
        lastSkillID = -1;//重置上一次触发的技能ID
        m_runtimeSkillCfg.SubCD(SubTime);//-CD,全体，包括自身
        return true;
    }
    public bool Invincible { get; set; }

    public event Action OnDeath;
    public event Return<bool> OnHurt = () => true;
    // Camera
    private CameraController camController;
    private Camera cam;
    /// <summary>
    /// 外部调用使主体受伤函数
    /// </summary>
    /// <param name="damage">伤害值</param>
    /// <param name="recoilForce">击退力</param>
    /// <param name="vignetteIntensity">不知道</param>
    /// <param name="killRecoil">不知道</param>
    public void Hurt(int damage, Vector2 recoilForce, float vignetteIntensity = 0.7f, bool killRecoil = true)
    {
        OnHurt?.Invoke();
        if (!CanBeHit || isDying) return; //处于无敌状态||正在死亡=>返回、

        Hp -= damage;//扣血

        float shakeIntensity = 0.5f;
        //camController.ShakeCamera(shakeIntensity);//相机抖动
        CameraEffects.Instance.Shake(shakeIntensity*200);

        if (Hp <= 0)//血量低于等于0=>死亡
        {
            BSaveData.Save();//保存
            SceneUtil.Instance.TransScene();//回到存档点
            if (!Invincible)//非无敌
            {
                KillPlayer(killRecoil);//抹杀主角
                animator.SetTrigger(CharacterAnimations.Die);//播放死亡动画
            }
        }

        CanBeHit = false;//进入无敌状态
        StartCoroutine(TQueueExtion.DelayFunc(()=>{CanBeHit = true; }, hitProtectionDuration)) ;//持续时间后移除
        EnableMoveCtrl = false;//禁用移动模块
        StartCoroutine(TQueueExtion.DelayFunc(()=> { EnableMoveCtrl = true; }, hitProtectionDuration/2));//持续时间后移除


        //Instantiate(hurtFlashObject, transform.position, Quaternion.identity);//受伤特效
        //GuiManager.Instance.FadeHurtVignette(vignetteIntensity);//受击背景
        GameManager.Instance.FreezeTime(0.02f);//冻结时间

        
        skillManager.Interrupt();//中断技能
        
        rigidbody2D.velocity = recoilForce;//击退
        
        // Recoil
       // DoRecoil(recoilForce);
    }

    /// <summary>
    /// 使主体击退
    /// </summary>
    /// <param name="recoilForce">作用力</param>
    /// <param name="resetVelocity">是否重置速度</param>
    public void DoRecoil(Vector2 recoilForce, bool resetVelocity = false)
    {
        if (resetVelocity)
            rigidbody2D.velocity = Vector3.zero;

        rigidbody2D.AddForce(recoilForce);
    }
    /// <summary>
    /// 使角色死亡
    /// </summary>
    /// <param name="recoil"></param>
    public void KillPlayer(bool recoil)
    {
        if (isDying)
            return;

        // Fade screen and respawn player at last save position
        // Restore HP and other stuff
        Invincible = true;

        if (recoil)
        {
            DoRecoil(new Vector2(0, 700.0f));
        }

        //SoundManager.Instance.PlaySound(deathSound, 1, audioSource);//死亡音效
        isDying = true;//正在死亡
        animator.SetBool("IsDying", true);//播放死亡动画

        OnDeath?.Invoke();//死亡委托
    }
    #endregion
}
