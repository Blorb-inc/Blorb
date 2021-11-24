using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
 
    float fallSpeed = 0.0f;


    bool isFalling = false;

    private void Update()
    {
        if (isFalling == true)
        {
            Destroy(gameObject, 10f);
            fallSpeed -= Time.deltaTime / 12f;
            transform.position = new Vector3(transform.position.x, (transform.position.y + fallSpeed), transform.position.z);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Waiter());
        } 
    }

    IEnumerator Waiter()
    {
        Animator anim = GetComponentInChildren<Animator>();
        float waitTime = 0.5f;
        anim.enabled = true;
        yield return new WaitForSeconds(waitTime);
        isFalling = true;
        
    }


}

