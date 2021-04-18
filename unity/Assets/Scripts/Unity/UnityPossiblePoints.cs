using UnityEngine;
using TMPro;
using Unity;

namespace Hexxle.Unity
{
    public class UnityPossiblePoints : MonoBehaviour
    {
        public TMP_Text possiblePointsText;
        public int possibleScore { get; set; } = 0;
        private Color32 originalColor;

        private void Awake()
        {
            originalColor = possiblePointsText.color;
        }

        void Update()
        {
            string text = "";
            if (possibleScore > 0)
            {
                possiblePointsText.color = new Color32(102, 193, 40, 255);
                text += "+";
            }
            else if (possibleScore < 0)
            {
                possiblePointsText.color = new Color32(255, 48, 40, 255);
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