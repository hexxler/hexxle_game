using UnityEngine;
using TMPro;
using Unity;

namespace Hexxle.Unity
{
    public class UnityPossiblePoints : MonoBehaviour
    {
        public TMP_Text possiblePointsText;
        public int possibleScore { get; set; } = 0;
        public Color32 positiveColor = new Color32(102, 193, 40, 255);
        public Color32 negativeColor = new Color32(255, 48, 40, 255);
        private Color32 originalColor;

        private void Awake()
        {
            originalColor = possiblePointsText.color;
        }

        void FixedUpdate()
        {
            string text = "";
            if (possibleScore > 0)
            {
                possiblePointsText.color = positiveColor;
                text += "+";
            }
            else if (possibleScore < 0)
            {
                possiblePointsText.color = negativeColor;
            }
            else
            {
                possiblePointsText.color = originalColor;
            }
            possiblePointsText.text = text + possibleScore;
            possiblePointsText.ForceMeshUpdate(true);
        }

    }
}