using System.Collections;
using System.Collections.Generic;
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
        if ((int)GameManager.Instance.playerSize == 2)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                rigidBody.AddForce(collision.gameObject.GetComponent<Rigidbody>().velocity * (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude * 100f), ForceMode.Impulse);
                AudioManager.instance.Play("WallExplosion");
                Destroy(gameObject, 2f); 

            }
        }
    }
}

