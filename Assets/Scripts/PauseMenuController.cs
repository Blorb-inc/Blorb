using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public void MenuButton ()
    {
        GameManager.GameIsPaused = false;
        SceneManager.LoadScene(0);
    }
    public void RestartButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
        Time.timeScale = 1;
        GameManager.GameIsPaused = false;
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
        GameManager.GameIsPaused = false;
    }
    public void Display()
    {

    }
    public void Hide()
    {

    }
}
