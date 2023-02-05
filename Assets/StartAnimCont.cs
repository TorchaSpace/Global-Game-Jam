using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAnimCont : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Kontrolcu());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("FinalGameScene");
        }
    }

    IEnumerator Kontrolcu()
    {
        yield return new WaitForSeconds(32.3f);
        SceneManager.LoadScene("FinalGameScene");

    }
}
