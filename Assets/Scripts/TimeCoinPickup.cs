using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class TimeCoinPickup : MonoBehaviour
{
    float reduceTime = 5f;
    float rotSpeed = 120; // degrees per second

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World); // <- Rotates coin
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reduces -5 seconds to TimerController
            //Destroy(gameObject); // This destroys pickup
            AudioManager.Instance.Play("Chomp");
            Finish.Instance.currentScore -= reduceTime;

        }
    }
}
