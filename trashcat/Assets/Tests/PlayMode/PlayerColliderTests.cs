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
        // public CharacterDatabase characterDatabase;
        [SetUp]
        public void SetUp()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
        private void StartGame()
        {
            string name = "StartButton";
            GameObject startButton = GameObject.Find(name);
            var setupButton = startButton.GetComponent<Button>();
            setupButton.onClick.AddListener(Clicked);
            setupButton.onClick.Invoke();
        }
        private void Clicked()
        {
            clicked = true;
        }
        [UnityTest]
        public IEnumerator PlayerIsInvincibleTest()
        {
            character = GameObject.Find("CharacterSlot");
            // character = GameObject.Find("PlayerPivot");
            var startObject = GameObject.Find("StartButton");
            yield return new WaitForSeconds(1);
            Assert.NotNull(startObject);
            var startButton = startObject.GetComponent<Button>();
            startButton.onClick.AddListener(Clicked);
            startButton.onClick.Invoke();
            yield return new WaitForSeconds(1);
            Assert.IsTrue(clicked);
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
