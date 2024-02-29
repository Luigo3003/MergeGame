using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject panelToDeactivate;
    public GameObject InputsPlayer;
    public GameObject UIGame;
    void Start()
    {
        

    }

    public void StartGame()
    {
        panelToDeactivate.SetActive(false);
        UIGame.SetActive(true);

        Time.timeScale = 1f;

    }
}
