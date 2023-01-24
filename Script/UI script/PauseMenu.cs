using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPause = false;
    public GameObject PauseMenuUI;


   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
    }

     public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;
    }

    public void quit()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
}
