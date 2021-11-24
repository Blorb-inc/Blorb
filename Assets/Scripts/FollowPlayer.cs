using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    public Transform playerObject;

     


    // Update is called once per frame
    public void Update()
    {
        gameObject.transform.position = playerObject.transform.position;
       
    }
}
