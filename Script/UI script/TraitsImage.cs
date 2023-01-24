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
    public bool isActiv=false;//�������Ƿ񼤻�
    public GameObject text;//��������
    protected Highlighter highlighter;//��������

    bool isOver = false;//����Ƿ���������
    

    void Start()
    {
        img = GetComponent<Image>();
        highlighter = gameObject.GetComponent<Highlighter>();
    }

    void Update()
    {
        if(isOver==true)
        {
            text.SetActive(true);//������������

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

    //�������
    public void Activa()
    {
        if(ImportantVariables.traitsPoints>0)
        { 
            img.color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (255 / 255f));//ͼƬ����
            ImportantVariables.traitsPoints--;//���ʵ�����һ
            isActiv = true;
        }
    }
    //���ȡ������ѡ��
    public void Cancel()
    {
        if(isActiv==true)
        {
            img.color = new Color((83 / 255f), (85 / 255f), (85 / 255f), (255 / 255f));//ͼƬ�䰵
            ImportantVariables.traitsPoints++;
            isActiv = false;
        }
    }
}
