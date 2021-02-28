using System.Collections;
using NUnit.Framework;
using PlayerLogic;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerHealthTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void maximumHealthIsCorrect()
        {
            var playerHealth = new GameObject().AddComponent<PlayerHealth>();
            Assert.AreEqual(100, playerHealth.getMaxHealth());
        }

        public void minimumHealthIsCorrect()
        {
            var playerHealth = new GameObject().AddComponent<PlayerHealth>();
            Assert.AreEqual(0, playerHealth.getMinHealth());
        }

    }
}
