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
                Assert.Fail();
                yield break;
            }

            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            var x = player.transform.position.x;
            playerMovement.moveLeft();

            yield return new WaitForSeconds(2f);

            Assert.IsTrue(player.transform.position.x < x);
            
        }

        [UnityTest]
        public IEnumerator MovePlayerRight()
        {
            yield return new WaitWhile(() => sceneLoaded == false);
            var player = getPlayerObject();

            if (player == null)
            {
                Assert.Fail();
                yield break;
            }

            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            var x = player.transform.position.x;
            playerMovement.moveRight();

            yield return new WaitForSeconds(2f);

            Assert.IsTrue(player.transform.position.x > x);
        }

        [UnityTest]
        public IEnumerator MovePlayerForward()
        {
            yield return new WaitWhile(() => sceneLoaded == false);
            var player = getPlayerObject();

            if (player == null)
            {
                Assert.Fail();
                yield break;
            }

            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            var z = player.transform.position.z;
            playerMovement.moveForward();

            yield return new WaitForSeconds(2f);

            Assert.IsTrue(player.transform.position.z > z);
        }

        [UnityTest]
        public IEnumerator MovePlayerBack()
        {
            yield return new WaitWhile(() => sceneLoaded == false);
            var player = getPlayerObject();

            if (player == null)
            {
                Assert.Fail();
                yield break;
            }

            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            var z = player.transform.position.z;
            playerMovement.moveBackwards();

            yield return new WaitForSeconds(2f);

            Assert.IsTrue(player.transform.position.z < z);
        }

        [UnityTest]
        public IEnumerator MakePlayerJump()
        {
            yield return new WaitWhile(() => sceneLoaded == false);
            var player = getPlayerObject();

            if (player == null)
            {
                Assert.Fail();
                yield break;
            }

            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            var y = player.transform.position.y;
            playerMovement.jump();

            yield return new WaitForSeconds(0.5f);

            Assert.IsTrue(player.transform.position.y > y);
        }


        private GameObject getPlayerObject()
        {
            return GameObject.Find("Player");
        }
    }
}
