using Assets.Scripts.Interfaces;
using Assets.Scripts.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Hexxle.Unity
{
    public class UnityPoints : MonoBehaviour
    {
        IGameScore score;
        public TMP_Text pointsText;

        private void Awake()
        {
            score = new Score();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            pointsText.text = GetPointsString();
        }

        public void IncreasePoints(int amount)
        {
            score.IncreaseScore(amount);
        }

        public int CurrentPoints()
        {
            return score.GetCurrentScore();
        }

        private string GetPointsString()
        {
            var currentPoints = score.GetCurrentScore();
            var nextThreshold = score.GetNextScoreThreshold();
            return $"{currentPoints} / {nextThreshold}";
        }
    }

}