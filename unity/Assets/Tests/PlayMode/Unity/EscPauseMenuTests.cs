using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Assets.Scripts.Util;

namespace Hexxle.Tests.Unity
{
    public class EscPauseMenuTests : InputTestFixture
    {
        Keyboard keyboard;
        Mouse mouse;
        InputManager inputManager;
        InputAction escapePressAction;

        [SetUp]
        public void Setup()
        {
            keyboard = InputSystem.AddDevice<Keyboard>();
            mouse = InputSystem.AddDevice<Mouse>();
            inputManager = new InputManager();
            escapePressAction = inputManager.MenuInteraction.Pause;
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
        [UnityTest]
        public IEnumerator PressingEscChangesFromMainSceneToTitlescreen()
        {
            Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
            escapePressAction.Enable();
            Press(keyboard.escapeKey);
            using (var trace = new InputActionTrace())
            {
                trace.SubscribeTo(escapePressAction);


                escapePressAction.Disable();

                //Checks to see if the action was executed exactly once
                Assert.AreEqual(1, trace.count);
            }

            yield return new WaitForSecondsRealtime(1);

            Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
            Assert.IsTrue(GameObjectFinder.PausePanel.activeSelf);
        }


    }
}
