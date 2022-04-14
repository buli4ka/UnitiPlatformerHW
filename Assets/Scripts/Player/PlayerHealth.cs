using UnityEngine;
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

        [FormerlySerializedAs("_playerHealth")] [SerializeField]
        private int playerHealth = 100;

        private static readonly int Dead = Animator.StringToHash("Dead");

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage(collision);
            Heal(collision);
            Death();
            healthText.text = $"Health: {playerHealth.ToString()}";
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
    }
}