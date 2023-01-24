using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HighlightingSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TraitsImage : MonoBehaviour
{
    private Image img;
    public bool isActiv=false;//该特质是否激活
    public GameObject text;//文字描述
    protected Highlighter highlighter;//高亮轮廓

    bool isOver = false;//鼠标是否在物体上
    

    void Start()
    {
        img = GetComponent<Image>();
        highlighter = gameObject.GetComponent<Highlighter>();
    }

    void Update()
    {
        if(isOver==true)
        {
            text.SetActive(true);//特质描述激活

        }
        else if(isOver==false)
        {
            text.SetActive(false);
        }
    }

    public void MouseEner()
    {
        isOver = true;
    }

    public void MouseExit()
    {
        isOver = false;
    }

    //点击激活
    public void Activa()
    {
        if(ImportantVariables.traitsPoints>0)
        { 
            img.color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (255 / 255f));//图片变亮
            ImportantVariables.traitsPoints--;//特质点数减一
            isActiv = true;
        }
    }
    //点击取消激活选中
    public void Cancel()
    {
        if(isActiv==true)
        {
            img.color = new Color((83 / 255f), (85 / 255f), (85 / 255f), (255 / 255f));//图片变暗
            ImportantVariables.traitsPoints++;
            isActiv = false;
        }
    }
}
