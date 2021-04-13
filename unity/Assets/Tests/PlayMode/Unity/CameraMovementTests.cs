using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Hexxle.Tests.Unity
{
    public class CameraMovementTests : InputTestFixture
    {
        Keyboard keyboard;
        Mouse mouse;
        InputManager inputManager;

        InputAction movementAction;
        InputAction zoomAction;

        [SetUp]
        public void Setup()
        {
            keyboard = InputSystem.AddDevice<Keyboard>();
            mouse = InputSystem.AddDevice<Mouse>();
            inputManager = new InputManager();
            movementAction = inputManager.CameraMovement.Move;
            zoomAction = inputManager.CameraMovement.Zoom;
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        [UnityTest]
        public IEnumerator ScrollingDownIncreasesCameraSize()
        {
            float initialSize = Camera.main.orthographicSize;
            zoomAction.Enable();
            Move(mouse.scroll, new Vector2(0, -1));

            using (var trace = new InputActionTrace())
            {
                trace.SubscribeTo(zoomAction);
                zoomAction.Disable();

                Assert.AreEqual(1, trace.count);
            }
            yield return new WaitForSecondsRealtime(1);
            Assert.Greater(Camera.main.orthographicSize, initialSize);
        }

        [UnityTest]
        public IEnumerator ScrollingUpDecreasesCameraSize()
        {
            float initialSize = Camera.main.orthographicSize;
            zoomAction.Enable();
            Move(mouse.scroll, new Vector2(0,1));

            using (var trace = new InputActionTrace())
            {
                trace.SubscribeTo(zoomAction);
                zoomAction.Disable();

                Assert.AreEqual(1, trace.count);
            }
            yield return new WaitForSecondsRealtime(1);
            Assert.Less(Camera.main.orthographicSize, initialSize);
        }

        [UnityTest]
        public IEnumerator PressingWIncreasesZPosition()
        {
            float initialZ = Camera.main.transform.position.z;
            movementAction.Enable();
            Press(keyboard.wKey);

            using (var trace = new InputActionTrace())
            {
                trace.SubscribeTo(movementAction);
                movementAction.Disable();

                Assert.AreEqual(1, trace.count);
            }
            yield return new WaitForSecondsRealtime(1);
            Assert.Greater(Camera.main.transform.position.z, initialZ);
        }

        [UnityTest]
        public IEnumerator PressingSDecreasesZPosition()
        {
            float initialZ = Camera.main.transform.position.z;
            movementAction.Enable();
            Press(keyboard.sKey);

            using (var trace = new InputActionTrace())
            {
                trace.SubscribeTo(movementAction);
                movementAction.Disable();

                Assert.AreEqual(1, trace.count);
            }
            yield return new WaitForSecondsRealtime(1);
            Assert.Less(Camera.main.transform.position.z, initialZ);
        }

        [UnityTest]
        public IEnumerator PressingDIncreasesXPosition()
        {
            float initialX = Camera.main.transform.position.x;
            movementAction.Enable();
            Press(keyboard.dKey);

            using (var trace = new InputActionTrace())
            {
                trace.SubscribeTo(movementAction);
                movementAction.Disable();

                Assert.AreEqual(1, trace.count);
            }
            yield return new WaitForSecondsRealtime(1);
            Assert.Greater(Camera.main.transform.position.x, initialX);
        }

        [UnityTest]
        public IEnumerator PressingADecreasesXPosition()
        {
            float initialX = Camera.main.transform.position.x;
            movementAction.Enable();
            Press(keyboard.aKey);

            using (var trace = new InputActionTrace())
            {
                trace.SubscribeTo(movementAction);
                movementAction.Disable();

                Assert.AreEqual(1, trace.count);
            }
            yield return new WaitForSecondsRealtime(1);
            Assert.Less(Camera.main.transform.position.x, initialX);
        }
    }
}
