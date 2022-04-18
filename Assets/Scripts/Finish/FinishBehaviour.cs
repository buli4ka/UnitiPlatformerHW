using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Finish
{
    public class FinishBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioSource finishSoundEffect;
        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name != "Player") return;
            CompleteLevel();
        }

        private void CompleteLevel()
        {
            finishSoundEffect.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}