using UnityEngine;
using UnityEngine.SceneManagement;
namespace Tests
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

    }
}
