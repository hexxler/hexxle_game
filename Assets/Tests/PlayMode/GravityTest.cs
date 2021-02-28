using System.Collections;
using NUnit.Framework;
using PlayerLogic;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine;

namespace Tests
{
    public class GravityTest
    {
        string sceneName = "TestScene";
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
        public IEnumerator GravityWorks()
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
            resetRigidbodyVelocity(player.GetComponent<Rigidbody>());
            debugPosition(player.transform.position);
            var y = player.transform.position.y;
            Debug.Log("moving player forwards");
            playerMovement.moveForward();

            yield return new WaitForSeconds(3f);

            Debug.Log("rechecking player position");
            debugPosition(player.transform.position);
            Assert.IsTrue(player.transform.position.y < y);

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

