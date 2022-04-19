using UnityEngine;
using UnityEngine.SceneManagement;

namespace Navigation
{
    public class EndMenu : MonoBehaviour
    {
        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
