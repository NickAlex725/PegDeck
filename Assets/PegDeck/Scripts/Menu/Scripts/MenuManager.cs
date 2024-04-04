using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PegDeck, where you play peggle and a card game.");
    }

    public void Quitgame()
    {
        Application.Quit();
        Debug.Log("The game just quit, get out!");
    }


}
