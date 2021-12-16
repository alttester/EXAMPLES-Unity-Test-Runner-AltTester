using Altom.AltUnityDriver;
using System;

namespace AltUnityTests.pages
{
    public class GamePlay : BasePage
    {
        public GamePlay(AltUnityDriver driver) : base(driver)
        {
        }

        public AltUnityObject PauseButton { get => Driver.WaitForObject(By.NAME, "Game/WholeUI/pauseButton", timeout: 2); }
        public AltUnityObject Character { get => Driver.WaitForObject(By.NAME, "PlayerPivot"); }

        public bool IsDisplayed()
        {
            if (PauseButton != null && Character != null)
            {
                return true;
            }
            return false;
        }
        public void PressPause()
        {
            PauseButton.Tap();
        }
        public int GetCurrentLife()
        {
            return Int32.Parse(Character.CallComponentMethod("CharacterInputController", "get_currentLife", ""));
        }
        


        
    }
}
