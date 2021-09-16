using Altom.AltUnityDriver;
using AltUnityTests.pages;
using System;
using System.Threading;
using NUnit.Framework;


namespace AltUnityTests.tests
{
    public class MainMenuTests : IDisposable
    {
        AltUnityDriver altUnityDriver;
        MainMenuPage mainMenuPage;

        public void Dispose()
        {
            altUnityDriver.Stop();
            Thread.Sleep(1000);
        }
        public MainMenuTests()
        {
            altUnityDriver = new AltUnityDriver();
            mainMenuPage = new MainMenuPage(altUnityDriver);
            mainMenuPage.LoadScene();

        }


        [Test]
        public void TestMainMenuPageLoadedCorrectly()
        {
            Assert.True(mainMenuPage.IsDisplayed());
        }
    }


}