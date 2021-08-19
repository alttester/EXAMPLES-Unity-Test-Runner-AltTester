using NUnit.Framework;
using Altom.AltUnityDriver;

public class AltUnityTest
{
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver =new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test]
    public void TestFindObjectsInScene()
    {
        altUnityDriver.LoadScene("Game");
        var altElements = altUnityDriver.FindObjects(By.PATH, "/Game");
        Assert.AreEqual(1, altElements.Count);
        Assert.AreEqual("Ship", altUnityDriver.FindObject(By.PATH, "/Game/Ship").name);

    }


}