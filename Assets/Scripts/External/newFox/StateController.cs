using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    //私有状态代理
    private IState m_state;
    // Start is called before the first frame update
    void Start()
    {
        m_state = FoxState.idle;
        m_state.enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        // 代理更新
        m_state.update();
    }
    //改变状态
    public void ChangeState(IState state)
    {
        //调用前一个状态的退出函数
        m_state.exit();
        //状态改变
        m_state = state;
        //调用新状态进入函数
        m_state.enter(this);
    }
    
    public void Return()
    {
        //返回站立状态
        ChangeState(FoxState.idle);
    }
    public void ReturnDown()
    {
        //返回下落状态
        ChangeState(FoxState.down);
    }
    public void ReturnUp()
    {
        ChangeState(FoxState.up);
    }
    
    public GameObject LoadPrefabs(string path)
    {
        GameObject prefab = (GameObject)Instantiate(Resources.Load(path));
        return prefab;
    }
}
