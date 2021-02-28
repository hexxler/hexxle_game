using UnityEngine;

namespace PlayerLogic
{
    public class Player : MonoBehaviour
    {

        new Rigidbody rigidbody;
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        
        public void moveLeft()
        {
            rigidbody.AddForce(Vector3.left*10f*Time.deltaTime, ForceMode.Acceleration);
        }

        public PlayerHealth getPlayerHealth()
        {
            return GetComponent<PlayerHealth>();
        }

        public PlayerMovement getPlayerMovement()
        {
            return GetComponent<PlayerMovement>();
        }

        
    }
}

