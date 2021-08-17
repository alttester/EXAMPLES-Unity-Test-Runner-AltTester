using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            GameObject gameGameObject = 
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
            game = gameGameObject.GetComponent<Game>();
    
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
    
            float initialYPos = asteroid.transform.position.y;
    
            yield return new WaitForSeconds(0.1f);
    
            Assert.Less(asteroid.transform.position.y, initialYPos);
    
            Object.Destroy(game.gameObject);
            yield return null;
        }
    }
}
