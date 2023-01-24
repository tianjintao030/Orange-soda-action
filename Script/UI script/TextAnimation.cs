using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    public Text text;
    private Button btn;
    bool isOver = false;//鼠标是否在物体上

    void Start()
    {
        btn = GetComponent<Button>();
    }

    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        isOver = true;
        text.color = Color.blue; 
        Vector2 pos = btn.transform.position;
        btn.transform.position = new Vector2(pos.x + 40f, pos.y);

    }

    public void OnMouseExit()
    {
        isOver = false;
        text.color = Color.black;
        Vector2 pos = btn.transform.position;
        btn.transform.position = new Vector2(pos.x - 40f, pos.y);
    }
}
