using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollView : MonoBehaviour
{
 

    void Update()
    {
        //�����ֵ�Ч��
        //��С
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 8)//���������Ұ��Χ�Ĳ���
                Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in�Ŵ�
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 15)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 0.5F;
        }
    }

   
}
