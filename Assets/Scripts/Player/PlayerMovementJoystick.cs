using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovementJoystick : MonoBehaviour
    {
        #region Parameters
        private Rigidbody _rb;
        [SerializeField] private float moveForce;
        [SerializeField] private float turnForce;
        private PlayerInput _playerInput;
        #endregion

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _rb = GetComponent<Rigidbody>();
        }
        
        // Update is called once per frame
        void FixedUpdate()
        {
            Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();
            
            //Accelerating and breaking
            _rb.AddForce(input.y * Vector3.forward * moveForce, ForceMode.Force);
            //Moving left and right
            _rb.AddForce(input.x * Vector3.right * turnForce, ForceMode.Force);
            Debug.Log(input);
        }

        
        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, Vector3.forward);
        }

    }
}
