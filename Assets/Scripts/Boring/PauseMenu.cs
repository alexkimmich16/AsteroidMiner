using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;
    public GameObject menu;

    void Start()
    {
        Continue();
    }

    public void Pause()
    {
        menu.SetActive(true);
        Paused = true;

        Time.timeScale = 0f;
    }
    public void Continue()
    {
        menu.SetActive(false);
        Paused = false;
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        BikeController.instance.Restart();
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }

}
