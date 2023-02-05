using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    public GameObject restartMenu;
   

    private void Start()
    {
        StartCoroutine(Kontrolcu());
    }

    IEnumerator Kontrolcu()
    {
        yield return new WaitForSeconds(8);
        restartMenu.SetActive(true);
    }
}
