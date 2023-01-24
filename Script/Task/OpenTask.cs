using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenTask : MonoBehaviour
{
    public GameObject TaskPanelUI;
    public bool isTaskpanelopen = false;

    public void openTaskUI()
    {
        if(isTaskpanelopen==false)
        {
            TaskPanelUI.SetActive(true);
            isTaskpanelopen = true;
            Time.timeScale = 0;
        }
    }
    public void closeTaskUI()
    {
        if (isTaskpanelopen==true)
        {
            TaskPanelUI.SetActive(false);
            isTaskpanelopen = false;
            Time.timeScale = 1;
        }
    }
}
