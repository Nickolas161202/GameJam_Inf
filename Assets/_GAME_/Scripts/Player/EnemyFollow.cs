    using UnityEngine;

    public class EnemyFollow : MonoBehaviour
    {
        public float speed = 3f; // Adjust this value for enemy speed
        [SerializeField] Transform playerTarget; // Reference to the player's transform
        [SerializeField] Rigidbody2D rb; // Reference to enemy's Rigidbody2D
        [SerializeField] float minDistance = 2f; // Desired range
        [SerializeField] float deadZone = 0.1f;


        void FixedUpdate()
        {
            if (playerTarget != null && rb != null)
            {   
                float distance = Vector2.Distance(rb.position, playerTarget.position);
                if (distance > minDistance)
                {
                    Vector2 targetPosition = Vector2.MoveTowards(rb.position, (Vector2)playerTarget.position, speed * Time.fixedDeltaTime);
                    rb.MovePosition(targetPosition);
                }
                else if (distance < minDistance - deadZone)
                {
                    // Move away from the player to stay within range
                    Vector2 directionAway = (rb.position - (Vector2)playerTarget.position).normalized;
                    Vector2 moveAwayPosition = rb.position + directionAway * speed * Time.fixedDeltaTime;
                    rb.MovePosition(moveAwayPosition);
                }
            }
        }
    }