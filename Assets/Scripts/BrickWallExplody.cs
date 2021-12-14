using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class BrickWallExplody : MonoBehaviour
{
    private Rigidbody rigidBody;
 
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
             if ((int)GameManager.Instance.currentSize >= 2)
            {
                rigidBody.AddForce(collision.gameObject.GetComponent<Rigidbody>().velocity * (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude * 100f), ForceMode.Impulse);
                AudioManager.Instance.Play("WallExplosion");
                Destroy(gameObject, 2f);
            }
        }
    }
}

