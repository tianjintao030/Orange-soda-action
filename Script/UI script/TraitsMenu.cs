using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitsMenu : MonoBehaviour
{
    public GameObject TraitsMenuUI;
    public bool isTraitsopen=false;

    void Update()
    {
        
    }

    public void OpenTraits()
    {
        if(isTraitsopen==false)
        {
            TraitsMenuUI.SetActive(true);
            isTraitsopen = true;
            Time.timeScale = 0;
        }
    }

    public void CloseTraits()
    {
        if (isTraitsopen == true)
        {
            TraitsMenuUI.SetActive(false);
            isTraitsopen = false;
            Time.timeScale = 1;
        }
    }
}
