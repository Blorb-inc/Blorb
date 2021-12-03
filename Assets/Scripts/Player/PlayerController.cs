using System.Collections;
using Player.States;
using UnityEngine;

namespace Player
{
    public class PlayerController : StateMachine
    {
        #region Variables
         
        [SerializeField]
        private Rigidbody rigidBody;
        [SerializeField]
        private AnimationCurve jumpPowerCurve;
        [SerializeField]
        private float jumpPower;
        [SerializeField]
        private float bigJumpPower;

        [SerializeField]
        private ParticleSystem smokePoof;
        [SerializeField]
        private GameObject speedFlame;

        private Transform gameCamera;

        private float currentJumpPower;
        private float moveSpeed = 750f;
        private Vector3 velocity;

        public float fallMultiplier = 2.5f;

        private float playerMass = 10f;
        private float curveEval;
        private SphereCollider CharCollider;

        // Variables Small Player Dash
        private bool isDashing;
        private float dashStartTime;
        float speedDash;


        // Variables Medium Player Jump
        private bool isGrounded;
        private bool isJumping;
        float minJump;

        // Variables Large Player Pound
        private bool isPounding;
        private float poundStartTime;

        private Coroutine sizeRoutine;

        public float AbilityCoolDown = 5f;
        private float NextAbilityUse;
        #endregion

        public void Setup(Transform gameCam)
        {
            gameCamera = gameCam;
        }

        private void Awake()
        {
            CharCollider = GetComponent<SphereCollider>();
        }

        public void Update()
        {
            minJump -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                if ((int)GameManager.Instance.playerSize > 0)
                {
                    SetSizeTo((PlayerSize)GameManager.Instance.playerSize - 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                if ((int)GameManager.Instance.playerSize < 2)
                {
                    SetSizeTo((PlayerSize)GameManager.Instance.playerSize + 1);
                }
            }
        }
        private void PlayerAbility()
        {
           
        }

        private void Landed(float power)
        {
            if (power > 6f)
            {
                smokePoof.Play();
                AudioManager.instance.Play("JumpLand");
            }
        }

        private void GroundCheck()
        {
            int mask = LayerMask.GetMask("Ground");
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 100f, mask, QueryTriggerInteraction.Ignore))
            {
                bool Grounded = hit.distance < ((CharCollider.radius * transform.localScale.y) + 0.05f);
                if (isGrounded == false && Grounded)
                {
                
                    Landed(rigidBody.velocity.magnitude);
                }

                isGrounded = Grounded;
                Debug.Log(isGrounded);
            }
            else
            {
                isGrounded = false;
            }
        }

        public void FixedUpdate()
        {
            GroundCheck();
            PlayerAbility();
            MoveInput();
        
            if (isGrounded == false)
            {
                Vector3 currentVelocity = rigidBody.velocity;
                currentVelocity.y -= 2f * Time.fixedDeltaTime;
                rigidBody.velocity = currentVelocity;
            }

        }
        void MoveInput()
        {
            Vector3 InputVector;

            Vector3 camDirectionForward = gameCamera.forward;
            camDirectionForward.y = 0f;
            InputVector = (camDirectionForward * Input.GetAxis("Vertical"));

            Vector3 camDirectionRight = gameCamera.right;
            camDirectionRight.y = 0f;
            InputVector += (camDirectionRight * Input.GetAxis("Horizontal"));

            velocity = Vector3.MoveTowards(velocity, InputVector.normalized * ((moveSpeed + speedDash) * Time.fixedDeltaTime), 40f * Time.fixedDeltaTime);

            if (velocity.magnitude < 0f)
                transform.forward = velocity;

            // SMALL DASH
            if (isDashing == true)
            {
                dashStartTime -= Time.deltaTime;

                if (dashStartTime < 0)
                {
                    speedFlame.SetActive(false);
                    dashStartTime = 0f;
                    speedDash = 0f;
                    isDashing = false;
                }
            }
            // JUMP
            if (isJumping && curveEval < 1f)
            {
                float jumpValue = jumpPowerCurve.Evaluate(curveEval);
                velocity.y = jumpValue * currentJumpPower;
            }
            else
            {
                isJumping = false;
                velocity.y = rigidBody.velocity.y;
            }

            rigidBody.velocity = velocity;
        }

        void SetSizeTo(PlayerSize nextSize)
        {
            if (sizeRoutine != null)
            {
                StopCoroutine(sizeRoutine);
                sizeRoutine = null;
            }
            GameManager.Instance.playerSize = nextSize;
            sizeRoutine = StartCoroutine(SizeChangeRoutine(nextSize));
        }

        IEnumerator SizeChangeRoutine(PlayerSize targetSize)
        {
            float targetMoveSpeed = 750f;
            float timer = 1f;
            float targetFieldofView = 50f;
            Vector3 targetScale = Vector3.one;
            float targetMass = playerMass;

            switch (targetSize)
            {
                case PlayerSize.Small:
                    targetScale = Vector3.one * 0.5f;
                    targetMoveSpeed = 750f * 1.4f;
                    targetFieldofView = 55f;
                    rigidBody.mass = playerMass / 2f;
                    jumpPower = 0f;
                    GameManager.Instance.cineCam.GetRig(2);
                    isJumping = false;
                    break;

                case PlayerSize.Medium:
                    targetScale = Vector3.one;
                    targetMoveSpeed = 750f;
                    targetFieldofView = 50f;
                    rigidBody.mass = playerMass;
                    jumpPower = 5f;
                    GameManager.Instance.cineCam.GetRig(1);
                    isJumping = false;
                    break;

                case PlayerSize.Large:
                    targetScale = Vector3.one * 2.5f;
                    targetMoveSpeed = 650f;
                    targetFieldofView = 45f;
                    rigidBody.mass = playerMass * 50f;
                    jumpPower = 2f;
                    GameManager.Instance.cineCam.GetRig(0);
                    isJumping = false;
                    break;
            }

            while (timer > 0f)
            {
                transform.localScale = Vector3.Lerp(targetScale, transform.localScale, timer);
                moveSpeed = Mathf.Lerp(targetMoveSpeed, moveSpeed, timer);
                playerMass = Mathf.Lerp(targetMass, playerMass, timer);
                GameManager.Instance.cineCam.m_Lens.FieldOfView = Mathf.Lerp(targetFieldofView, GameManager.Instance.cineCam.m_Lens.FieldOfView, timer);
                timer -= Time.deltaTime * 0.15f;
                yield return null;
            }
            yield break;
        }
    }
}



