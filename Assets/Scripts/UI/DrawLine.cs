using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [Header("Point")]
    //[SerializeField]public RectTransform startPoint;//起始点，UI用
    //public RectTransform endPoint;//终点，UI用
    public GameObject linePrefab;//一个空物体下挂一个SpriteRender就行了
    public float lineWidth;//线的宽度
    private RectTransform m_rect;//自己的RectTrans
    //private GameObject m_line;//线的实例
    //private RectTransform m_lineRect;//线的RectTransfrom
    [Header("Multi")]
    public List<RectTransform> endPoints=new List<RectTransform>();//终点列表
    private List<GameObject> m_lines=new List<GameObject>();//线实例列表
    private List<RectTransform> m_lineRects=new List<RectTransform>();//线的RectTransfrom

    [SerializeField] List<RSkillInfo> infos;
    private void Awake()
    {
        m_rect = GetComponent<RectTransform>();
    }
    private void Start()
    {
        //m_line = CreateLine(m_rect.anchoredPosition, endPoint.anchoredPosition);
        //下方UI要加，世界坐标下不需要
        //不明白函数意思看文档，作用是防止线段遮挡视野（层级不同可能会遮挡）
        //m_line.transform.SetAsFirstSibling();
        //多点
        foreach(var elem in endPoints)
        {
            var newLine = Instantiate(linePrefab, transform.parent);
            newLine.transform.SetAsFirstSibling();//设置层级
            m_lines.Add(newLine);//添加
            m_lineRects.Add(newLine.GetComponent<RectTransform>());//添加
        }
        DrawMulitLine(); //仅绘制一次
    }
    private void Update()
    {
        // DrawStraightLine(m_line, m_rect.anchoredPosition, endPoint.anchoredPosition);
        //多线
        // DrawMulitLine();每一帧都绘制
    }
    /// <summary>
    /// 创建一条两点之间的线
    /// </summary>
    /// <param name="startPoint">起始点</param>
    /// <param name="endPoint">结束点</param>
    public GameObject CreateLine(Vector2 startPoint, Vector2 endPoint)
    {
        GameObject line = Instantiate(linePrefab, transform.parent);
       // m_lineRect = line.GetComponent<RectTransform>();
        return line;
    }
    //划线功能
    private void DrawStraightLine(GameObject line, Vector2 a, Vector2 b)
    {
        float distance = Vector2.Distance(a, b);                                    //求距离
        float angle = Vector2.SignedAngle(a - b, Vector2.left);                     //求夹角
        //line.GetComponent<RectTransform>().anchoredPosition = (a + b) / 2;
        //line.GetComponent<RectTransform>().sizeDelta = new Vector2(distance, lineWidth);   //长度，宽度
        //m_lineRect.anchoredPosition = (a + b) / 2;
       // m_lineRect.sizeDelta = new Vector2(distance, lineWidth);
        line.transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    }
    private void DrawMulitLine()
    {
        for (int i = 0; i < m_lines.Count; i++)
        {
            float distance = Vector2.Distance(m_rect.anchoredPosition, endPoints[i].anchoredPosition);                                    //求距离
            float angle = Vector2.SignedAngle(m_rect.anchoredPosition - endPoints[i].anchoredPosition, Vector2.left);                     //求夹角
            //line.GetComponent<RectTransform>().anchoredPosition = (a + b) / 2;
           //line.GetComponent<RectTransform>().sizeDelta = new Vector2(distance, lineWidth);   //长度，宽度
            m_lineRects[i].anchoredPosition = (m_rect.anchoredPosition + endPoints[i].anchoredPosition) / 2;
            m_lineRects[i].sizeDelta = new Vector2(distance, lineWidth);
            m_lines[i].transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        }
    }
}

