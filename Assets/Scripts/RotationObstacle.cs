using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObstacle : MonoBehaviour
{
    float rotSpeed = 20; // degrees per second

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World); // <- Rotates coin
    }
}
