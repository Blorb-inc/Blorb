using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovementJoystick : MonoBehaviour
    {
        #region Parameters
        
        //Components
        private Rigidbody _rb;
        private PlayerInput _playerInput;
        
        [Header("Player stats")]
        [SerializeField] private float turnForce;
        [SerializeField] private float smallSpeed;
        [SerializeField] private float boostSpeed;
        [SerializeField] private float mediumSpeed;
        [SerializeField] private float mediumJump;
        [SerializeField] private float largeSpeed;
        [SerializeField] private float largeJump;
        [SerializeField] private float currentSpeed;
        
        private float scaleDuration = 1;
        private bool _isScaling = false;
        private bool _isBoosting = false;

        #endregion

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            currentSpeed = mediumSpeed;
            _rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();

            //Accelerating and breaking
            _rb.AddForce(input.y * Vector3.forward * currentSpeed, ForceMode.Force);
            //Moving left and right
            _rb.AddForce(input.x * Vector3.right * turnForce, ForceMode.Force);
        }

        public void SetSize(int state)
        {
            if (_isScaling) return;
            Vector3 sizeToScale = default;
            switch (state)
            {
                case 0:
                    sizeToScale = new Vector3(.5f, .5f, .5f);
                    currentSpeed = smallSpeed;
                    break;
                case 1:
                    sizeToScale = Vector3.one;
                    currentSpeed = mediumSpeed;
                    break;
                case 2:
                    sizeToScale = new Vector3(2, 2, 2);
                    currentSpeed = largeSpeed;
                    break;
                default: Debug.LogError($"State {state} does not exist or is not reachable");
                    break;
            }

            StartCoroutine(ScaleOverTime(sizeToScale));
        }

        private IEnumerator ScaleOverTime(Vector3 toScale)
        {
            if (_isScaling) yield break;

            _isScaling = true;

            float counter = 0;

            Vector3 startSize = transform.localScale;

            while (counter < scaleDuration)
            {
                counter += Time.deltaTime;
                transform.localScale = Vector3.Lerp(startSize, toScale, counter / scaleDuration);
                yield return null;
            }
            _isScaling = false;
        }
        
        public void Ability(int state)
        {
            switch (state)
            {
                case 0:
                    StartCoroutine(SpeedBoost());
                    break;
                case 1: _rb.AddForce(Vector3.up*mediumJump);
                    break;
                case 2: _rb.AddForce(Vector3.up*largeJump);
                    break;
                default: Debug.LogError($"Ability error at state {state}");
                    break;
            }
        }

        private IEnumerator SpeedBoost()
        {
            if (_isBoosting) yield break;
            currentSpeed += boostSpeed;
            yield return new WaitForSeconds(3);
            currentSpeed -= boostSpeed;
        }
    }
}