using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        [FormerlySerializedAs("HealthText")] [SerializeField]
        private Text healthText;

        [SerializeField] private Text bananasText;


        [FormerlySerializedAs("_playerHealth")] [SerializeField]
        private int playerHealth = 100;

        private int _collectedBananas = 0;

        private static readonly int Dead = Animator.StringToHash("Dead");

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CollectBanana(collision);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage(collision);
            Heal(collision);
            Death();
            healthText.text = $"Health: {playerHealth.ToString()}";
        }

        private void CollectBanana(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("BananaItem")) return;

            Destroy(collision.gameObject);
            _collectedBananas++;
            bananasText.text = $"Bananas: {_collectedBananas.ToString()}";
        }

        private void Damage(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Traps")) return;

            playerHealth -= 14;
        }

        private void Heal(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("AppleItem")) return;
            Destroy(collision.gameObject);
            playerHealth += 10;
            if (playerHealth > 100)
            {
                playerHealth = 100;
            }
        }

        private void Death()
        {
            if (playerHealth >= 1) return;
            playerHealth = 0;
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
            _animator.SetTrigger(Dead);
        }

        private void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}