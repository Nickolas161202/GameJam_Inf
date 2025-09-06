    using UnityEngine;

    public class EnemyFollow : MonoBehaviour
    {
    public float speed = 3f; // Adjust this value for enemy speed
    [SerializeField] Transform playerTarget; // Reference to the player's transform
    [SerializeField] Rigidbody2D rb; // Reference to enemy's Rigidbody2D

        void FixedUpdate()
        {
        if (playerTarget != null && rb != null)
        {
            // Calculate the direction from the enemy to the player
            Vector2 direction = ((Vector2)playerTarget.position - rb.position).normalized;

            // Move the enemy towards the player using Rigidbody2D
            Vector2 targetPosition = Vector2.MoveTowards(rb.position, (Vector2)playerTarget.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(targetPosition);

        }
        }
    }