using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private float stoppingDistance;

    public static CameraController Instance;
    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _target.position.z-stoppingDistance);
    }
}
