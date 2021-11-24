using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public enum PlayerSize
{
    Small = 0,
    Medium = 1,
    Large = 2
}

public enum GameState
{
    Start = 0,
    GameOver = 1,
    Loading = 2,
    Menu = 3
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool tutorials;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private PlayerSpotlight playerSpotLight;
    [SerializeField]
    private GameObject camPrefab;
    [SerializeField]
    private GameObject lightPrefab;

    public CinemachineFreeLook cineCam;

    public static bool gameIsPaused;
    public static bool stopWatchActive;


    public PlayerSize playerSize;

    private GameObject startPoint;

    private void Awake()
    {
        Time.timeScale = 1;
        PlayerController player = Instantiate(playerPrefab).GetComponent<PlayerController>();
        player.transform.position = GameObject.FindGameObjectWithTag("Start").transform.position;
        playerSize = PlayerSize.Medium;
        GameObject camObject = Instantiate(camPrefab);
       // GameObject dirLight = Instantiate(lightPrefab);
        cineCam = camObject.GetComponentInChildren<CinemachineFreeLook>();
        cineCam.Follow = player.transform;
        cineCam.LookAt = player.transform;
        if(playerSpotLight != null)
        {
            playerSpotLight.Setup(player);
        }  
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive); // Loads HUD as overlay in other scenes
        Instance = this;
        player.Setup(camObject.GetComponentInChildren<Camera>().transform);
       
    }

    private void Start()
    {
       
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) // <- Brings up PauseMenu
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R)) // <- Reset Map
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

       
    }

    void PauseGame() // This function pauses game and loads pause menu
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("PauseMenu");
            gameIsPaused = false;
        }


   
    }
}


 


 