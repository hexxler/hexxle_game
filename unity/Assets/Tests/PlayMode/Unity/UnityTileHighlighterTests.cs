using NUnit.Framework;
using UnityEngine.TestTools;
using Hexxle.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Hexxle.Tests.Unity
{
    public class UnityTileHighlighterTests
    {
        UnityTileHighlighter tileHighlighter;

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }


        [UnityTest]
        public IEnumerator HighlighterIsDisabledAtTheStart()
        {
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));
            tileHighlighter = GameObject.FindGameObjectsWithTag("Tile")[0].GetComponent<UnityTileHighlighter>();
            Assert.IsFalse(tileHighlighter.enabled);

        }

        [UnityTest]
        public IEnumerator EnablingAndDisablingTileHighlighterWorks()
        {
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(SceneManager.GetActiveScene().name.Equals("Main"));
            tileHighlighter = GameObject.FindGameObjectsWithTag("Tile")[0].GetComponent<UnityTileHighlighter>();
            Assert.IsFalse(tileHighlighter.enabled);
            tileHighlighter.enabled = true;
            Assert.IsTrue(tileHighlighter.enabled);
            tileHighlighter.enabled = false;
            Assert.IsFalse(tileHighlighter.enabled);

        }
    }
}
