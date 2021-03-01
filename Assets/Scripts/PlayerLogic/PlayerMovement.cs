using UnityEngine;

namespace PlayerLogic
{
    public class PlayerMovement : MonoBehaviour
    {
        public float movementForce = 300f;
        public float jumpForce = 100f;
        Vector3 movementDirection;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            movementDirection = new Vector3();
            if (Input.GetKey(KeyCode.A))
            {
                moveLeft();
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveRight();
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveForward();
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveBackwards();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                jump();
            }
        }

        private void FixedUpdate()
        {
            move();
        }

        public void moveLeft()
        {
            movementDirection += Vector3.left;
        }

        public void moveRight()
        {
            movementDirection += Vector3.right;
        }

        public void moveForward()
        {
            movementDirection += Vector3.forward;
        }

        public void moveBackwards()
        {
            movementDirection += Vector3.back;
        }

        public void jump()
        {
            movementDirection += Vector3.up;
        }

        private void move()
        {
            if(!movementDirection.Equals(new Vector3()))
            {
                Debug.Log("Moving in the direction " + movementDirection.ToString());
                var xForce = movementDirection.x * movementForce * Time.deltaTime;
                var yForce = movementDirection.y * jumpForce * Time.deltaTime;
                var zForce = movementDirection.z * movementForce * Time.deltaTime;
                gameObject.GetComponent<Rigidbody>().AddForce(xForce, 0, zForce, ForceMode.Acceleration);
                gameObject.GetComponent<Rigidbody>().AddForce(0, yForce, 0, ForceMode.VelocityChange);
            }
        }
    }
}


