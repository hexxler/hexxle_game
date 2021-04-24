using UnityEngine;

namespace Hexxle.Unity
{
    public class UnityTileHighlighter : MonoBehaviour
    {
        //smaller -> slower
        private readonly float INVERSE_PERIOD_DURATION = 0.4f;
        private readonly float MAX_EMISSION_POWER = 0.2f;
        public Color glowColor = Color.white;
        
        void FixedUpdate()
        {
            var material = GetComponent<Renderer>().material;
            var emission = Mathf.PingPong(Time.time * INVERSE_PERIOD_DURATION, MAX_EMISSION_POWER);
            emission = Mathf.LinearToGammaSpace(emission);
            material.SetColor("_EmissionColor", glowColor * emission);
        }

        private void OnDisable()
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }


    }
}
