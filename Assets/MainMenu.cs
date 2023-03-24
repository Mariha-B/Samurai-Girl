using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public void PlayGame()
    {   //Loads Level 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );

    }

    public void QuitGame()
    {
        //Quits application
        Application.Quit();

    }


    private void Update()
    {   //Esp to Pause game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
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
    {   //Disables pause menu
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;


    }
    
    void Pause()
    {   //Pause Menu and freezes time
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;


    }
    public void LoadMenu()
    {   //Loads MainMenu
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }

    public void LoadLevel()
    {   //Loads Level one
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelOne");

    }

}
