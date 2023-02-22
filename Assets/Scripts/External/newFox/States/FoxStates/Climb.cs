using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : FoxState
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        LockLocation();
        //初始化跳跃次数
        m_fox.jumpCount = 2;
        //取消重力
        m_rigidbody2D.gravityScale = 0;
        //取消碰撞效果,改变为触发器
        m_stateController.GetComponent<PolygonCollider2D>().isTrigger = true;
        m_stateController.GetComponent<BoxCollider2D>().isTrigger = true;
        //播放climb动画
        m_animator.Play("climb");
    }
    public override void update()
    {
        //由于不再调用基类的基本移动以及射击效果，故不再调用基类更新方法
        //攀爬移动
        ClimbMent();
        //离开梯子时
        if(!m_fox.inLadder)
        {
            //切换回到站立状态
            m_stateController.ChangeState(FoxState.idle);
        }
        //攀爬跳跃
        Jump();
    }
    public override void exit()
    {
        //还原碰撞效果
        m_stateController.GetComponent<PolygonCollider2D>().isTrigger = false;
        m_stateController.GetComponent<BoxCollider2D>().isTrigger = false;
        //还原重力
        m_rigidbody2D.gravityScale = 3;
    }
    void ClimbMent()
    {
        //攀爬
        float verticalmove = Input.GetAxisRaw("Vertical");
        m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x,verticalmove * m_fox.speed );
    }
    void Jump()
    {
        //如果有合法跳跃输入
        if (m_fox.jumpPressed)
        {
            //切换为跳跃状态
            m_stateController.ChangeState(FoxState.up);
            m_fox.jumpPressed = false;
        }
    }
    void LockLocation()
    {
        //进入climb状态时锁定位置
        m_rigidbody2D.velocity = new Vector2(0, 0);
        m_transform.position = new Vector3(m_fox.Ladder.position.x, m_transform.position.y, m_transform.position.z);
    }
}
