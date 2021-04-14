using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Hexxle.Unity.Tests
{
    public class TilePlacementTest
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
        public IEnumerator ThereIsExactlyOneTileTaggedWithTileAtTheStart()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));

            //in case the mapscript isnt done
            yield return new WaitForSecondsRealtime(1f);

            Assert.AreEqual(1, GameObject.FindGameObjectsWithTag("Tile").Length);

        }

        [UnityTest]
        public IEnumerator ThereAreExactlySixVoidTilesAtTheStart()
        {
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));

            //in case the mapscript isnt done
            yield return new WaitForSecondsRealtime(1f);

            Assert.AreEqual(6, GameObject.FindGameObjectsWithTag("Void").Length);

            yield return null;
        }
    }
}
