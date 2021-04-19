using System.Collections;
using Hexxle.Unity;
using Hexxle.Unity.Input;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Hexxle.Tests.Unity
{
    public class PossibleScoreTests
    {
        private string sceneToLoad = "Main";
        private UnityPossiblePoints unityPossiblePoints;


        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }

        private void SetupObjects()
        {
            unityPossiblePoints = GameObject.FindGameObjectWithTag("ScoreChange").GetComponent<UnityPossiblePoints>();
            DisableMouseEventHandler();
        }

        [UnityTest]
        public IEnumerator ScoreIsZeroAtTheStart()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));
            SetupObjects();

            //in case the mapscript isnt done
            yield return new WaitForSecondsRealtime(1f);
            Assert.AreEqual("0", unityPossiblePoints.possiblePointsText.text);
        }

        [UnityTest]
        public IEnumerator ScoreIsGreenWhenScoreChangeIsPositive()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));
            SetupObjects();

            unityPossiblePoints.possibleScore = 1;
            yield return new WaitForFixedUpdate();
            Color color = unityPossiblePoints.positiveColor;
            Assert.AreEqual(color, unityPossiblePoints.possiblePointsText.color);
        }

        [UnityTest]
        public IEnumerator PositiveScoreHasPlusPrefix()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));
            SetupObjects();

            int score = 1;
            unityPossiblePoints.possibleScore = score;
            yield return new WaitForFixedUpdate();
            Assert.AreEqual("+" + score, unityPossiblePoints.possiblePointsText.text);
        }

        [UnityTest]
        public IEnumerator NegativeScoreHasMinusPrefix()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));
            SetupObjects();

            int score = -1;
            unityPossiblePoints.possibleScore = score;
            yield return new WaitForFixedUpdate();
            Assert.AreEqual(score.ToString(), unityPossiblePoints.possiblePointsText.text);
        }

        [UnityTest]
        public IEnumerator ScoreIsRedWhenScoreChangeIsNegative()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));
            SetupObjects();

            unityPossiblePoints.possibleScore = -1;
            yield return new WaitForFixedUpdate();
            Color color = unityPossiblePoints.negativeColor;
            Assert.AreEqual(color, unityPossiblePoints.possiblePointsText.color);
        }

        [UnityTest]
        public IEnumerator ScoreIsBackToOriginalColorWhenSettingToZero()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));
            SetupObjects();

            Color originalColor = unityPossiblePoints.possiblePointsText.color;
            unityPossiblePoints.possibleScore = 1;
            yield return new WaitForFixedUpdate();
            Assert.AreNotEqual(originalColor, unityPossiblePoints.possiblePointsText.color);
            unityPossiblePoints.possibleScore = 0;
            yield return new WaitForFixedUpdate();
            Assert.AreEqual(originalColor, unityPossiblePoints.possiblePointsText.color);
        }

        private void DisableMouseEventHandler()
        {
            GameObject.Find("Game").GetComponent<MouseEventsHandler>().enabled = false;
        }
    }
}
