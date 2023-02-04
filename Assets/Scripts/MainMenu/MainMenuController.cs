using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject song;

    public void StartButton()
    {
        Destroy(song);
        SceneManager.LoadSceneAsync("");
    }
  

    public void QuitButton()
    {
        Application.Quit();
    }
}
