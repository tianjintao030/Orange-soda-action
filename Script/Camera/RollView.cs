using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollView : MonoBehaviour
{
 

    void Update()
    {
        //鼠标滚轮的效果
        //缩小
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 8)//调节最大视野范围的参数
                Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in放大
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 15)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 0.5F;
        }
    }

   
}
