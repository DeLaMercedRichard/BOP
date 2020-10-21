using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject Pausemenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Paused)
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

        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    void Pause()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
}
