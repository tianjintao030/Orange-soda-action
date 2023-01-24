using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class HighlightOperate : MonoBehaviour
{
    // ����������ʾ��
    protected Highlighter highlighter;

    // Start is called before the first frame update
    void Start()
    {
        // ��ø�����ʾ�����
        highlighter = gameObject.GetComponent<Highlighter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ��껬��
    void OnMouseEnter()
    {
        // ����һֱ����
        highlighter.ConstantOn();
        // ����һֱ��������ָ����ɫ
        highlighter.ConstantOn(Color.yellow);
    }

    // ��껬��
    void OnMouseExit()
    {
        // �ر�һֱ����
        highlighter.ConstantOff();
    }
}
