using UnityEngine;

namespace Player
{
    public class PlayerMovementArrows : MonoBehaviour
    {
        #region Parameters
        
        private Rigidbody _rb;
        [SerializeField] private float moveForce=100f;
        [SerializeField] private float brakeForce=20f;
        [SerializeField] private float jumpForce=1000f;

        [HideInInspector]
        public bool isAcceleratePressed;
        [HideInInspector]
        public bool isDeceleratePressed;
        [HideInInspector]
        public bool isLeftPressed;       
        [HideInInspector]
        public bool isRightPressed;
        
          #endregion
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isAcceleratePressed)
            {
                Accelerate();
            }

            if (isDeceleratePressed)
            {
                Decelerate();
            }

            if (isLeftPressed)
            {
                GoLeft();
            }

            if (isRightPressed)
            {
                GoRight();
            }
        }

        

        private void Accelerate()
        {
            _rb.AddForce(Vector3.forward *moveForce);
        }

        private void Decelerate()
        {
            _rb.AddForce(Vector3.back*brakeForce);
        }

        private void GoLeft()
        {
           _rb.AddForce(Vector3.left*moveForce);
        }

        private void GoRight()
        {
            _rb.AddForce(Vector3.right*moveForce);
        }
        
        public void Jump()
        {
            _rb.AddForce(Vector3.up*jumpForce);
        }
        
        /// <summary>
        /// Gets called when the forward button is pushed down
        /// </summary>
        public void OnPointerDownForwardButton()
        {
            isAcceleratePressed = true;
        }
        
         /// <summary>
         /// Gets called when the back button is pushed down
         /// </summary>
        public void OnPointerDownBackButton()
        {
            isDeceleratePressed = true;
        }
        
         /// <summary>
         /// Gets called when the player stops pushing down the forward button
         /// </summary>
        public void OnPointerUpForwardButton()
        {
            isAcceleratePressed = false;
        } 
         /// <summary>
         /// Gets called when the player stops pushing down the back button
         /// </summary>
         public void OnPointerUpBackButton()
         { 
             isDeceleratePressed = false;
         }
         
         /// <summary>
         /// Gets called when the left button is pushed down
         /// </summary>
        public void OnPointerDownLeftButton()
        {
            isLeftPressed = true;
        }
        
         /// <summary>
         /// Gets called when the player stops pushing down the left button
         /// </summary>
        public void OnPointerUpLeftButton()
        {
            isLeftPressed = false;
        } 
         /// <summary>
         /// Gets called when the right button is pushed down
         /// </summary>
        public void OnPointerDownRightButton()
        {
            isRightPressed= true;
        }
        
         /// <summary>
         /// Gets called when the player stops pushing down the right button
         /// </summary>
        public void OnPointerUpRightButton()
        {
            isRightPressed = false;
        }
         
        
    }
}
