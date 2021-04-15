using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Hexxle.Unity.Util;

namespace Hexxle.Tests.Unity
{
    public class EscPauseMenuTests : InputTestFixture
    {
        Keyboard keyboard;
        InputAction escapePressAction;

        [SetUp]
        public void Setup()
        {
            keyboard = InputSystem.AddDevice<Keyboard>();
            escapePressAction = new InputManager().MenuInteraction.Pause;
            escapePressAction.Enable();
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        [UnityTest]
        public IEnumerator PressingEscOpensPauseMenu()
        {
            Assert.IsTrue(escapePressAction.enabled);
            Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
            PressAndRelease(keyboard.escapeKey);
            yield return new WaitForSecondsRealtime(1);
            Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
            Assert.IsTrue(GameObjectFinder.PausePanel.activeSelf);
        }

        [UnityTest]
        public IEnumerator PressingEscTwiceTwiceClosesPauseMenu()
        {

            PressAndRelease(keyboard.escapeKey);
            yield return new WaitForSecondsRealtime(1);
            PressAndRelease(keyboard.escapeKey);
            yield return new WaitForSecondsRealtime(1);
            Assert.IsFalse(GameObjectFinder.PausePanel.activeSelf);
        }

        [UnityTest]
        public IEnumerator PausingGameSetsMouseEventHandlerToPauseMode()
        {
            Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
            Assert.IsFalse(GameObjectFinder.MouseEventLogic.isGamePaused);
            PressAndRelease(keyboard.escapeKey);
            yield return new WaitForSecondsRealtime(1);
            Assert.IsTrue(GameObjectFinder.MouseEventLogic.isGamePaused);
        }

        [UnityTest]
        public IEnumerator ResumingGameSetsMouseEventHandlerToNormalMode()
        {
            Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
            Assert.IsFalse(GameObjectFinder.MouseEventLogic.isGamePaused);
            PressAndRelease(keyboard.escapeKey);
            yield return new WaitForSecondsRealtime(1);
            PressAndRelease(keyboard.escapeKey);
            yield return new WaitForSecondsRealtime(1);

            Assert.IsFalse(GameObjectFinder.MouseEventLogic.isGamePaused);
        }

    }
}
