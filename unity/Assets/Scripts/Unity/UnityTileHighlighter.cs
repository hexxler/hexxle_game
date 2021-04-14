using UnityEngine;

namespace Hexxle.Unity
{
    public class UnityTileHighlighter : MonoBehaviour
    {

        public bool isHighlighted { get; private set; }
        private bool setToBlackOnce;
        //smaller -> slower
        private readonly float INVERSE_PERIOD_DURATION = 0.4f;
        private readonly float MAX_EMISSION_POWER = 0.2f;
        private readonly Color GLOW_COLOR = Color.white;
        

        // Start is called before the first frame update
        void Start()
        {
            isHighlighted = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            if (isHighlighted)
            {
                var material = GetComponent<Renderer>().material;
                var emission = Mathf.PingPong(Time.time * INVERSE_PERIOD_DURATION, MAX_EMISSION_POWER);
                emission = Mathf.LinearToGammaSpace(emission);
                material.SetColor("_EmissionColor", GLOW_COLOR * emission);
            }
            else if(setToBlackOnce)
            {
                var material = GetComponent<Renderer>().material;
                material.SetColor("_EmissionColor", Color.black);
                setToBlackOnce = false;
            }
        }

        public void TurnOn()
        {
            isHighlighted = true;
            setToBlackOnce = false;
        }

        public void TurnOff()
        {
            isHighlighted = false;
            setToBlackOnce = true;
        }

        
    }
}
