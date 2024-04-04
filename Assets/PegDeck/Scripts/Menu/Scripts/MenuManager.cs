using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject testButton;

    void doExitGame()
    {
        Application.Quit();
    }

    void doPlayGame()
    {

    }

    public void doCredits()
    {
        testButton.gameObject.SetActive(false);
    }
}
