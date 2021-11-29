using UnityEngine;

namespace Player
{
    public class AntonsPlayerMovement : MonoBehaviour
    {
        #region Parameters
        
        private Rigidbody rb;
        [SerializeField] private float moveForce=100f;
        [SerializeField] private float brakeForce=20f;
        [SerializeField] private float jumpForce=1000f;

        public bool isAcceleratePressed;
        public bool isDeceleratePressed;
        
          #endregion
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
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
        }

        private void Accelerate()
        {
            rb.AddForce(Vector3.forward *moveForce);
        }

        private void Decelerate()
        {
            rb.AddForce(Vector3.back*brakeForce);
        }

        public void Jump()
        {
            rb.AddForce(Vector3.up*jumpForce);
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
        /// Gets called when the player stops pushing down the forward button
        /// </summary>
        public void OnPointerUpBackButton()
        {
            isDeceleratePressed = false;
        }
    }
}
