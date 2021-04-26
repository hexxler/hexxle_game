using Assets.Scripts.Interfaces;
using Assets.Scripts.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Hexxle.Unity
{
    public class UnityPoints : MonoBehaviour
    {
        IGameScore score;
        public TMP_Text pointsText;
        public Slider pointProgress;

        private float smoothPoints = 0;
        private float smoothScoreThreshold = 10;

        private UnityStack stack;
        private UnityHand hand;

        private void Awake()
        {
            score = new Score();
            stack = GameObject.FindGameObjectWithTag("Stack").GetComponent<UnityStack>();
            hand = GameObject.FindGameObjectWithTag("Hand").GetComponent<UnityHand>();
        }

        // Update is called once per frame
        void Update()
        {
            pointsText.text = GetPointsString();

            pointProgress.value = smoothPoints;
            pointProgress.maxValue = smoothScoreThreshold;

            smoothPoints = Mathf.Lerp(smoothPoints, CurrentPoints(), 0.1f);
            smoothScoreThreshold = Mathf.Lerp(smoothScoreThreshold, score.GetNextScoreThreshold(), 0.1f);
        }

        public void IncreasePoints(int amount)
        {
            stack.AddNewRandomTiles(score.IncreaseScore(amount));
            hand.FillHand();
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