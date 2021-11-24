using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3[] points;
    public int pointNumber = 0;
    private Vector3 currentTarget;

    public float tolerance;
    public float speed;
    public float delayTime;

    private float delayStart;

    public bool automatic;

    private void Start()
    {
        if (points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (transform.position != currentTarget)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
    }

    void MovePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        delayStart = Time.time;
    }

    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - delayStart > delayTime)
            {
                NextPlatform();
            }
        }
    }
    public void NextPlatform()
    {
        pointNumber++; 
        if (pointNumber >= points.Length)
        {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }

}
