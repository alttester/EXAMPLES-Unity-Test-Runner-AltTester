using Altom.AltUnityDriver;
using AltUnityTests.pages;
using System;
using System.Threading;
using NUnit.Framework;
namespace AltUnityTests.tests
{
    public class StartPageTests : IDisposable
    {
        private AltUnityDriver altUnityDriver;
        private MainMenuPage mainMenuPage;
        private StartPage startPage;
        public StartPageTests()
        {
            altUnityDriver = new AltUnityDriver();
            startPage = new StartPage(altUnityDriver);
            startPage.Load();
            mainMenuPage = new MainMenuPage(altUnityDriver);

        }
        [Test]
        public void TestStartPageLoadedCorrectly()
        {
            Assert.True(startPage.IsDisplayed());
        }
        [Test]
        public void TestStartButtonLoadMainMenu()
        {
            startPage.PressStart();
            Assert.True(mainMenuPage.IsDisplayed());
        }

        public void Dispose()
        {
            altUnityDriver.Stop();
            Thread.Sleep(1000);
        }
    }
}