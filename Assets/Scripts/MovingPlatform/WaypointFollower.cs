using UnityEngine;

namespace MovingPlatform
{
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField] private GameObject[] waypoints;
        private int _currentIndex = 0;
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private float movementSpeed = 2f;
        [SerializeField] private bool flipXOn = false;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

        }
        private void Update()
        {
            if (Vector2.Distance(waypoints[_currentIndex].transform.position, transform.position) < .1f)
            {
                _currentIndex++;
                if (_currentIndex >= waypoints.Length)
                {
                    _currentIndex = 0;
                }

                if (flipXOn)
                {
                    _spriteRenderer.flipX = !_spriteRenderer.flipX;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position
                , waypoints[_currentIndex].transform.position
                , Time.deltaTime * movementSpeed);
        }
    }
}