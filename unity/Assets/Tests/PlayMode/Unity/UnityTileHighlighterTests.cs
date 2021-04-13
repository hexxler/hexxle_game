using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Hexxle.Unity;

namespace Hexxle.Tests.Unity
{
    public class UnityTileHighlighterTests
    {
        private string sceneToLoad = "Main";

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }

        [TearDown]
        public void TearDown()
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }

        [UnityTest]
        public IEnumerator TurningOnUnityTileHighlighterEnablesEmission()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));

            GameObject nonVoidTile = GameObject.FindGameObjectsWithTag("Tile")[0];

            Assert.NotNull(nonVoidTile.GetComponent<UnityTileHighlighter>());

            nonVoidTile.GetComponent<UnityTileHighlighter>().TurnOn();
            yield return new WaitForSecondsRealtime(2f);

            Assert.IsTrue(nonVoidTile.GetComponent<Renderer>().material.IsKeywordEnabled("_Emission"));

        }

        [UnityTest]
        public IEnumerator TurningOffUnityTileHighlighterDisablesEmissionAndSetsColorToBlack()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));


            GameObject nonVoidTile = GameObject.FindGameObjectsWithTag("Tile")[0];

            Assert.NotNull(nonVoidTile.GetComponent<UnityTileHighlighter>());

            nonVoidTile.GetComponent<UnityTileHighlighter>().TurnOn();
            yield return new WaitForSecondsRealtime(2f);
            Assert.IsTrue(nonVoidTile.GetComponent<Renderer>().material.IsKeywordEnabled("_Emission"));

            nonVoidTile.GetComponent<UnityTileHighlighter>().TurnOff();
            yield return new WaitForSecondsRealtime(2f);
            Assert.IsFalse(nonVoidTile.GetComponent<Renderer>().material.IsKeywordEnabled("_Emission"));
            Assert.AreEqual(Color.black, nonVoidTile.GetComponent<Renderer>().material.GetColor("_EmissionColor"));
                
            yield return null;
        }


    }
}
