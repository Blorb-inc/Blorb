using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public void MenuButton ()
    {
        GameManager.gameIsPaused = false;
        SceneManager.LoadScene(0);
    }
    public void RestartButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
        Time.timeScale = 1;
        GameManager.gameIsPaused = false;
    }
    public void LevelButton()
    {
         
    }
    public void HelpButton()
    {

    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("PauseMenu");
        GameManager.gameIsPaused = false;
    }
    public void Display()
    {

    }
    public void Hide()
    {

    }
}
