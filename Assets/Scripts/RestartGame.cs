using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public GameObject restartScreen;

    public static RestartGame restartGame;

    private void Start()
    {
        restartGame = this;
    }

    public void Restart()
    {
        restartScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("FinalGameScene");
    }

}
