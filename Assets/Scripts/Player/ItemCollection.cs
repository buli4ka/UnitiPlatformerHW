using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class ItemCollection : MonoBehaviour
    {
        private int _collectedBananas = 0;
        [SerializeField] private Text bananasText; 
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("BananaItem"))
            {
                Destroy(collision.gameObject);
                _collectedBananas++;
                bananasText.text = $"Bananas: {_collectedBananas.ToString()}";
            }
        }
    }
}