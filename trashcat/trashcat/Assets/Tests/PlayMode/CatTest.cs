using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CatTest
    {
        
        [UnityTest]
        public IEnumerator CatTestWithEnumeratorPasses()
        {
            var gameObject=new GameObject();
            var cat=gameObject.AddComponent<Character>();
            // GameObject gameGameObject = 
            // MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            // var game = gameGameObject.AddComponent<Game>();
            yield return null;
        }
    }
}
