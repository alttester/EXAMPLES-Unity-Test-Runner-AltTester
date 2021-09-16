using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;


namespace Tests
{
    public class PlayerControllerTests
    {
        bool clicked = false;
        public GameObject character;
        public GameObject startObject;
        [SetUp]
        public void SetUp()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
            character = GameObject.Find("PlayerPivot");
            // StartGame();
        }
        private void StartGame()
        {
            string name = "StartButton";
            GameObject startButton = GameObject.Find(name);

            var setupButton = startButton.GetComponent<Button>();
            setupButton.onClick.AddListener(Clicked);
            setupButton.onClick.Invoke();
        }
        [UnityTest]
        public IEnumerator StartGameTest()
        {
            var gameObject = new GameObject();
            string name = "StartButton";
            GameObject startButton = GameObject.Find(name);
            yield return new WaitForSeconds(5);
            Assert.NotNull(startButton);
            var setupButton = startButton.GetComponent<Button>();
            setupButton.onClick.AddListener(Clicked);
            setupButton.onClick.Invoke();
            yield return new WaitForSeconds(5);
            Assert.IsTrue(clicked);
        }
        // [UnityTest]
        // public IEnumerator PlayerIsPresentInSceneTest()
        // {
        //     character = GameObject.Find("PlayerPivot");
        //     yield return new WaitForSeconds(20);
        //     Assert.NotNull(character);
        // }
        [UnityTest]
        public IEnumerator PlayerJumpsTest()
        {
            character = GameObject.Find("PlayerPivot");
            startObject = GameObject.Find("StartButton");

            yield return new WaitForSeconds(1);
            Assert.NotNull(startObject);
            var startButton = startObject.GetComponent<Button>();
            startButton.onClick.AddListener(Clicked);
            startButton.onClick.Invoke();
            yield return new WaitForSeconds(1);
            Assert.IsTrue(clicked);

            yield return new WaitForSeconds(5);

            var controller = this.character.GetComponent<CharacterInputController>();
            controller.Jump();
            yield return new WaitForSeconds(0.5f);
            Assert.IsTrue(controller.m_Jumping);
            yield return new WaitForSeconds(1f);
            Assert.IsFalse(controller.m_Jumping);
        }
        [UnityTest]
        public IEnumerator PlayerJumpStopsTest()
        {
            character = GameObject.Find("PlayerPivot");
            startObject = GameObject.Find("StartButton");

            yield return new WaitForSeconds(1);
            Assert.NotNull(startObject);
            var startButton = startObject.GetComponent<Button>();
            startButton.onClick.AddListener(Clicked);
            startButton.onClick.Invoke();
            yield return new WaitForSeconds(1);
            Assert.IsTrue(clicked);

            yield return new WaitForSeconds(5);

            var controller = character.GetComponent<CharacterInputController>();
            controller.Jump();
            controller.Jump();
            controller.Jump();

            yield return new WaitForSeconds(5);
            Assert.IsTrue(controller.m_Jumping);
            controller.StopJumping();
            yield return new WaitForSeconds(5);
            Assert.IsFalse(controller.m_Jumping);

        }
        [UnityTest]
        public IEnumerator PlayerSlidesTest()
        {
            character = GameObject.Find("PlayerPivot");
            startObject = GameObject.Find("StartButton");

            yield return new WaitForSeconds(1);
            Assert.NotNull(startObject);
            var startButton = startObject.GetComponent<Button>();
            startButton.onClick.AddListener(Clicked);
            startButton.onClick.Invoke();
            yield return new WaitForSeconds(1);
            Assert.IsTrue(clicked);

            yield return new WaitForSeconds(5);
            var controller = character.GetComponent<CharacterInputController>();
            controller.Slide();

            yield return new WaitForSeconds(5);
            Assert.IsTrue(controller.m_Sliding);
        }

        [UnityTest]
        public IEnumerator PlayerCleanConsumablesTest()
        {
            character = GameObject.Find("PlayerPivot");
            startObject = GameObject.Find("StartButton");
            yield return new WaitForSeconds(1);
            Assert.NotNull(startObject);
            var startButton = startObject.GetComponent<Button>();
            startButton.onClick.AddListener(Clicked);
            startButton.onClick.Invoke();
            yield return new WaitForSeconds(1);
            Assert.IsTrue(clicked);

            yield return new WaitForSeconds(5);
            var controller = character.GetComponent<CharacterInputController>();
            var consumablesCount = controller.m_ActiveConsumables.Count;
            Assert.NotNull(consumablesCount);
            controller.CleanConsumable();
            yield return new WaitForSeconds(5);
            Assert.AreEqual(consumablesCount, 0);
        }

        [UnityTest]
        public IEnumerator PlayerChangesLaneTest()
        {
            character = GameObject.Find("PlayerPivot");
            startObject = GameObject.Find("StartButton");
            yield return new WaitForSeconds(1);
            Assert.NotNull(startObject);
            var startButton = startObject.GetComponent<Button>();
            startButton.onClick.AddListener(Clicked);
            startButton.onClick.Invoke();
            yield return new WaitForSeconds(1);
            Assert.IsTrue(clicked);

            yield return new WaitForSeconds(5);
            var controller = character.GetComponent<CharacterInputController>();
            controller.ChangeLane(1);
            yield return new WaitForSeconds(1);
            Assert.AreEqual(controller.m_CurrentLane, 2);
            controller.ChangeLane(-1);
            yield return new WaitForSeconds(1);
            Assert.AreEqual(controller.m_CurrentLane, 1);
            controller.ChangeLane(-1);
            yield return new WaitForSeconds(1);
            Assert.AreEqual(controller.m_CurrentLane, 0);
        }

        private void Clicked()
        {
            clicked = true;
        }
        private void clickStartButton()
        {
            var gameObject = new GameObject();
            string name = "StartButton";
            GameObject startButton = GameObject.Find(name);
            var setupButton = startButton.GetComponent<Button>();
            setupButton.onClick.AddListener(Clicked);
            setupButton.onClick.Invoke();
        }
    }
}
