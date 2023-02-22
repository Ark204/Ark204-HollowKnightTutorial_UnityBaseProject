using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    //˽��״̬����
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
        // �������
        m_state.update();
    }
    //�ı�״̬
    public void ChangeState(IState state)
    {
        //����ǰһ��״̬���˳�����
        m_state.exit();
        //״̬�ı�
        m_state = state;
        //������״̬���뺯��
        m_state.enter(this);
    }
    
    public void Return()
    {
        //����վ��״̬
        ChangeState(FoxState.idle);
    }
    public void ReturnDown()
    {
        //��������״̬
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
