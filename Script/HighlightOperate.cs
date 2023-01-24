using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class HighlightOperate : MonoBehaviour
{
    // 声明高亮显示器
    protected Highlighter highlighter;

    // Start is called before the first frame update
    void Start()
    {
        // 获得高亮显示器组件
        highlighter = gameObject.GetComponent<Highlighter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 鼠标滑入
    void OnMouseEnter()
    {
        // 开启一直高亮
        highlighter.ConstantOn();
        // 开启一直高亮，并指定颜色
        highlighter.ConstantOn(Color.yellow);
    }

    // 鼠标滑出
    void OnMouseExit()
    {
        // 关闭一直高亮
        highlighter.ConstantOff();
    }
}
