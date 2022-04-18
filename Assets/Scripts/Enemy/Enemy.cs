using System;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {

        private int _enemyHealth = 100;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.name == "Player")
            {
                _enemyHealth -= 20;
                Debug.Log(_enemyHealth.ToString());
            }
        }
    }
}