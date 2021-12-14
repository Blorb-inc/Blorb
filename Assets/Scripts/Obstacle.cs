using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if ((int)GameManager.Instance.currentSize >= 2)
        {
            _rb.isKinematic = false;
            _rb.AddForce(Vector3.forward * 100, ForceMode.Force);
            Destroy(gameObject, 2f);
        }
    }
}
