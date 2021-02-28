using System.Collections;
using NUnit.Framework;
using PlayerLogic;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine;

namespace Tests
{
    public class PlayerMovementTests
    {

        string sceneName = "sampleScene";
        bool sceneLoaded;


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            sceneLoaded = true;
        }


        [UnityTest]
        public IEnumerator MovePlayerLeft()
        {
            yield return new WaitWhile(() => sceneLoaded == false);
            var player = getPlayerObject();

            if (player == null)
            {
                Debug.Log("Couldnt retrieve player!");
                Assert.Fail();
                yield break;
            }

            resetRigidbodyVelocity(player.GetComponent<Rigidbody>());
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            playerMovement.movementForce *= 2;

            debugPosition(player.transform.position);
            var x = player.transform.position.x;
            Debug.Log("moving player left");
            playerMovement.moveLeft();
            Debug.Log("Player moved, waiting for movement to stop...");

            yield return new WaitForSeconds(2f);

            Debug.Log("rechecking player position");
            debugPosition(player.transform.position);
            Assert.IsTrue(player.transform.position.x < x);
            
        }

        [UnityTest]
        public IEnumerator MovePlayerRight()
        {
            yield return new WaitWhile(() => sceneLoaded == false);
            var player = getPlayerObject();

            if (player == null)
            {
                Debug.Log("Couldnt retrieve player!");
                Assert.Fail();
                yield break;
            }

            resetRigidbodyVelocity(player.GetComponent<Rigidbody>());
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            debugPosition(player.transform.position);
            var x = player.transform.position.x;
            Debug.Log("moving player right");
            playerMovement.moveRight();
            Debug.Log("Player moved, waiting for movement to stop...");

            yield return new WaitForSeconds(2f);

            Debug.Log("rechecking player position");
            debugPosition(player.transform.position);
            Assert.IsTrue(player.transform.position.x > x);
        }

        [UnityTest]
        public IEnumerator MovePlayerForward()
        {
            yield return new WaitWhile(() => sceneLoaded == false);
            var player = getPlayerObject();

            if (player == null)
            {
                Debug.Log("Couldnt retrieve player!");
                Assert.Fail();
                yield break;
            }

            resetRigidbodyVelocity(player.GetComponent<Rigidbody>());
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            debugPosition(player.transform.position);
            var z = player.transform.position.z;
            Debug.Log("moving player right");
            playerMovement.moveForward();
            Debug.Log("Player moved, waiting for movement to stop...");

            yield return new WaitForSeconds(2f);

            Debug.Log("rechecking player position");
            debugPosition(player.transform.position);
            Assert.IsTrue(player.transform.position.z > z);
        }

        [UnityTest]
        public IEnumerator MovePlayerBack()
        {
            yield return new WaitWhile(() => sceneLoaded == false);
            var player = getPlayerObject();

            if (player == null)
            {
                Debug.Log("Couldnt retrieve player!");
                Assert.Fail();
                yield break;
            }

            resetRigidbodyVelocity(player.GetComponent<Rigidbody>());
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            debugPosition(player.transform.position);
            var z = player.transform.position.z;
            Debug.Log("moving player backwards");
            playerMovement.moveBackwards();
            Debug.Log("Player moved, waiting for movement to stop...");

            yield return new WaitForSeconds(2f);

            Debug.Log("rechecking player position");
            debugPosition(player.transform.position);
            Assert.IsTrue(player.transform.position.z < z);
        }

        [UnityTest]
        public IEnumerator MakePlayerJump()
        {
            yield return new WaitWhile(() => sceneLoaded == false);
            var player = getPlayerObject();

            if (player == null)
            {
                Debug.Log("Couldnt retrieve player!");
                Assert.Fail();
                yield break;
            }

            resetRigidbodyVelocity(player.GetComponent<Rigidbody>());
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            debugPosition(player.transform.position);
            var y = player.transform.position.y;
            Debug.Log("making player jump");
            playerMovement.jump();
            Debug.Log("Player moved, waiting for movement to stop...");

            yield return new WaitForSeconds(0.5f);

            Debug.Log("rechecking player position");
            debugPosition(player.transform.position);
            Assert.IsTrue(player.transform.position.y > y);
        }



        private void debugPosition(Vector3 position)
        {
            Debug.Log("X: " + position.x);
            Debug.Log("Y: " + position.y);
            Debug.Log("Z: " + position.y);
        }

        private void resetRigidbodyVelocity(Rigidbody rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
        }

        private GameObject getPlayerObject()
        {
            return GameObject.Find("Player");
        }
    }
}
