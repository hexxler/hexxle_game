using UnityEngine;

namespace PlayerLogic
{
    public class PlayerHealth : MonoBehaviour
    {
        float maxHealth = 100f;
        float minHealth = 0f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public float getMaxHealth()
        {
            return maxHealth;
        }

        public float getMinHealth()
        {
            return minHealth;
        }
    }
}

