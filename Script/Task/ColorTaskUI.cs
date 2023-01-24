using System.Collections;
using System.Collections.Generic;
using System.IO;//Directory.Exists
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System;//Type
using System.Reflection;//FieldInfo

public class ColorTaskUI : MonoBehaviour
{
    [Header("自身Tag")]
    public Transform m_Tag;
    [Header("另外三个Tag")]
    public Transform tag1; 
    public Transform tag2;
    public Transform tag3;
    [Header("对应的Content")]
    public GameObject m_Cont;
    [Header("另外三个Content")]
    public GameObject con1;
    public GameObject con2;
    public GameObject con3;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    //点击Tag，切换Tag遮挡层级
    public void changeLayer()
    {
        m_Tag.SetAsLastSibling();
        tag1.SetAsFirstSibling();
        tag2.SetAsFirstSibling();
        tag3.SetAsFirstSibling();
    }
    //切换到对应区的任务
    public void changeRegion()
    {
        m_Cont.SetActive(true);
        con1.SetActive(false);
        con2.SetActive(false);
        con3.SetActive(false);
    }
}
