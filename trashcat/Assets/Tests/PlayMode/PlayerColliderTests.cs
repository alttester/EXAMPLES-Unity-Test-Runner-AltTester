using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class PlayerColliderTests
    {
        bool clicked = false;
        public GameObject character;
        [SetUp]
        public void SetUp()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }

        [UnityTest]
        public IEnumerator PlayerIsInvincibleTest()
        {
            character = GameObject.Find("CharacterSlot");
            var gameState = GameObject.Find("Loadout");
            yield return new WaitForSeconds(5);
            Assert.NotNull(gameState);
            var gameController = gameState.GetComponent<LoadoutState>();
            gameController.StartGame();

            yield return new WaitForSeconds(5);

            var collider = character.GetComponent<CharacterCollider>();
            collider.SetInvincible(10);
            yield return new WaitForSeconds(5);
            Assert.IsTrue(collider.m_Invincible);
            yield return new WaitForSeconds(5);
            Assert.IsFalse(collider.m_Invincible);
        }
    }
}

