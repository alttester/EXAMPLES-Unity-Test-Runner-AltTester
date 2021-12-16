using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;


namespace Tests
{
    public class PlayerControllerTests : MonoBehaviour
    {
        bool clicked = false;
        public GameObject character;
        public GameObject startObject;
        public GameState gameState;

        public GameObject gameOverPopup;

        public CharacterInputController controller1;
        [SetUp]
        public void SetUp()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");

        }

        [UnityTest]
        public IEnumerator TestStartGame()
        {

            var gameState = GameObject.Find("Loadout");
            yield return new WaitForSeconds(5);
            Assert.NotNull(gameState);
            var controller = gameState.GetComponent<LoadoutState>();
            controller.StartGame();

            var track = GameObject.Find("TrackManager");
            yield return new WaitForSeconds(2);
            Assert.NotNull(track);
        }


        [UnityTest]
        public IEnumerator TestPlayerJumps()
        {

            character = GameObject.Find("PlayerPivot");
            var gameState = GameObject.Find("Loadout");
            yield return new WaitForSeconds(5);
            Assert.NotNull(gameState);
            var gameController = gameState.GetComponent<LoadoutState>();
            gameController.StartGame();

            yield return new WaitForSeconds(5);

            var controller = this.character.GetComponent<CharacterInputController>();
            controller.Jump();
            yield return new WaitForSeconds(0.5f);
            Assert.IsTrue(controller.m_Jumping);
            yield return new WaitForSeconds(1f);
            Assert.IsFalse(controller.m_Jumping);
        }
        [UnityTest]
        public IEnumerator TestPlayerJumpStops()
        {
            
            character = GameObject.Find("PlayerPivot");
            var gameState = GameObject.Find("Loadout");
            yield return new WaitForSeconds(5);
            Assert.NotNull(gameState);
            var gameController = gameState.GetComponent<LoadoutState>();
            gameController.StartGame();

            yield return new WaitForSeconds(5);

            var controller = this.character.GetComponent<CharacterInputController>();
            controller.Jump();
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(controller.m_Jumping);
            controller.StopJumping();
            yield return new WaitForSeconds(0.1f);
            Assert.IsFalse(controller.m_Jumping);

        }
        [UnityTest]
        public IEnumerator TestPlayerSlide()
        {
            character = GameObject.Find("PlayerPivot");
            var gameState = GameObject.Find("Loadout");
            yield return new WaitForSeconds(5);
            Assert.NotNull(gameState);
            var gameController = gameState.GetComponent<LoadoutState>();
            gameController.StartGame();

            yield return new WaitForSeconds(5);
            var controller = character.GetComponent<CharacterInputController>();
            controller.Slide();

            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(controller.m_Sliding);
        }

        [UnityTest]
        public IEnumerator TestPlayerCleanConsumables()
        {
            character = GameObject.Find("PlayerPivot");
            var gameState = GameObject.Find("Loadout");
            yield return new WaitForSeconds(5);
            Assert.NotNull(gameState);
            var gameController = gameState.GetComponent<LoadoutState>();
            gameController.StartGame();

            yield return new WaitForSeconds(5);
            var controller = character.GetComponent<CharacterInputController>();
            var consumablesCount = controller.m_ActiveConsumables.Count;
            Assert.NotNull(consumablesCount);
            controller.CleanConsumable();
            yield return new WaitForSeconds(5);
            Assert.AreEqual(consumablesCount, 0);
        }

        [UnityTest]
        public IEnumerator TestPlayerChangesLane()
        {
            character = GameObject.Find("PlayerPivot");
            var gameState = GameObject.Find("Loadout");
            yield return new WaitForSeconds(5);
            Assert.NotNull(gameState);
            var gameController = gameState.GetComponent<LoadoutState>();
            gameController.StartGame();

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

    }
}
