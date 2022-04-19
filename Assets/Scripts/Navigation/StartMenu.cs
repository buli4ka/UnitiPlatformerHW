using UnityEngine;
using UnityEngine.SceneManagement;

namespace Navigation
{
    public class StartMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}