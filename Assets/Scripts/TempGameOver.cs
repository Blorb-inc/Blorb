using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempGameOver : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) // Goal Function
    {
        if (other.gameObject.tag == "Player")
        { 
            // GameObject.FindWithTag("Player").transform.position = GameObject.FindWithTag("Start").transform.position;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
