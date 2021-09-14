using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class StartPageTest
    {
        // A Test behaves as an ordinary method
        bool clicked = false;
        [SetUp]
        public void SetUp()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
        }
        [UnityTest]
        public IEnumerator StartPageTestWithEnumeratorPasses()
        {

            var gameObject = new GameObject();
            string name = "StartButton";
            GameObject startButton = GameObject.Find(name);
            Assert.NotNull(startButton);
            var setupButton = startButton.GetComponent<Button>();
            setupButton.onClick.AddListener(Clicked);
            setupButton.onClick.Invoke();
            Assert.IsTrue(clicked);
            yield return new WaitForSeconds(5);

            var loadedScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            Assert.AreEqual(loadedScene.name, "Main");

            yield return null;
        }
        private void Clicked()
        {
            clicked = true;
        }
    }
}
