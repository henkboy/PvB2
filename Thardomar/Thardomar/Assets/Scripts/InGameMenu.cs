using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Story1;
    public bool IsPaused;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if(IsPaused == true)
            {
                Continue();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Continue()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IsPaused = false;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        IsPaused = true;
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void StartGame()
    {
        Story1.SetActive(false);
    }
}