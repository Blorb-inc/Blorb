using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
  
    [SerializeField]
    private string SceneToLoad;

    public float currentScore;

    public static Finish Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        currentScore += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) // Goal Function
    {
        if (other.gameObject.tag == "Player")
        {
            if (currentScore <= PlayerPrefs.GetFloat("LevelHighScore" + SceneManager.GetActiveScene().buildIndex, currentScore))
            { 
                PlayerPrefs.SetFloat("LevelHighScore" + SceneManager.GetActiveScene().buildIndex, currentScore);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene(SceneToLoad);
            GameObject.FindWithTag("Player").transform.position = GameObject.FindWithTag("Start").transform.position;
        }
    }
}
