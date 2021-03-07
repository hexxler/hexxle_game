using UnityEngine;

namespace PlayerLogic
{
    public class Player : MonoBehaviour
    {

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

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

