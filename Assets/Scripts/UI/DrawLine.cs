using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [Header("Point")]
    //[SerializeField]public RectTransform startPoint;//��ʼ�㣬UI��
    //public RectTransform endPoint;//�յ㣬UI��
    public GameObject linePrefab;//һ���������¹�һ��SpriteRender������
    public float lineWidth;//�ߵĿ��
    private RectTransform m_rect;//�Լ���RectTrans
    //private GameObject m_line;//�ߵ�ʵ��
    //private RectTransform m_lineRect;//�ߵ�RectTransfrom
    [Header("Multi")]
    public List<RectTransform> endPoints=new List<RectTransform>();//�յ��б�
    private List<GameObject> m_lines=new List<GameObject>();//��ʵ���б�
    private List<RectTransform> m_lineRects=new List<RectTransform>();//�ߵ�RectTransfrom

    [SerializeField] List<RSkillInfo> infos;
    private void Awake()
    {
        m_rect = GetComponent<RectTransform>();
    }
    private void Start()
    {
        //m_line = CreateLine(m_rect.anchoredPosition, endPoint.anchoredPosition);
        //�·�UIҪ�ӣ����������²���Ҫ
        //�����׺�����˼���ĵ��������Ƿ�ֹ�߶��ڵ���Ұ���㼶��ͬ���ܻ��ڵ���
        //m_line.transform.SetAsFirstSibling();
        //���
        foreach(var elem in endPoints)
        {
            var newLine = Instantiate(linePrefab, transform.parent);
            newLine.transform.SetAsFirstSibling();//���ò㼶
            m_lines.Add(newLine);//���
            m_lineRects.Add(newLine.GetComponent<RectTransform>());//���
        }
        DrawMulitLine(); //������һ��
    }
    private void Update()
    {
        // DrawStraightLine(m_line, m_rect.anchoredPosition, endPoint.anchoredPosition);
        //����
        // DrawMulitLine();ÿһ֡������
    }
    /// <summary>
    /// ����һ������֮�����
    /// </summary>
    /// <param name="startPoint">��ʼ��</param>
    /// <param name="endPoint">������</param>
    public GameObject CreateLine(Vector2 startPoint, Vector2 endPoint)
    {
        GameObject line = Instantiate(linePrefab, transform.parent);
       // m_lineRect = line.GetComponent<RectTransform>();
        return line;
    }
    //���߹���
    private void DrawStraightLine(GameObject line, Vector2 a, Vector2 b)
    {
        float distance = Vector2.Distance(a, b);                                    //�����
        float angle = Vector2.SignedAngle(a - b, Vector2.left);                     //��н�
        //line.GetComponent<RectTransform>().anchoredPosition = (a + b) / 2;
        //line.GetComponent<RectTransform>().sizeDelta = new Vector2(distance, lineWidth);   //���ȣ����
        //m_lineRect.anchoredPosition = (a + b) / 2;
       // m_lineRect.sizeDelta = new Vector2(distance, lineWidth);
        line.transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    }
    private void DrawMulitLine()
    {
        for (int i = 0; i < m_lines.Count; i++)
        {
            float distance = Vector2.Distance(m_rect.anchoredPosition, endPoints[i].anchoredPosition);                                    //�����
            float angle = Vector2.SignedAngle(m_rect.anchoredPosition - endPoints[i].anchoredPosition, Vector2.left);                     //��н�
            //line.GetComponent<RectTransform>().anchoredPosition = (a + b) / 2;
           //line.GetComponent<RectTransform>().sizeDelta = new Vector2(distance, lineWidth);   //���ȣ����
            m_lineRects[i].anchoredPosition = (m_rect.anchoredPosition + endPoints[i].anchoredPosition) / 2;
            m_lineRects[i].sizeDelta = new Vector2(distance, lineWidth);
            m_lines[i].transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        }
    }
}

