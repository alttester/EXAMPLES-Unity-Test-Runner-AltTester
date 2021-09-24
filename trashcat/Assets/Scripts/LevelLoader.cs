using UnityEngine;
using UnityEngine.SceneManagement;
namespace Tests
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadLevel(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}
