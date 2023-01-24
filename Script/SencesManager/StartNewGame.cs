using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
   public void NewGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

    public void QuitGame()
    {
        Debug.Log("Àë¿ª");
        Application.Quit();
    }
}
