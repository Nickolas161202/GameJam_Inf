using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3f; // Adjust this value for enemy speed

    public float life = 3f;

    [SerializeField] Transform playerTarget; // Reference to the player's transform
    [SerializeField] Rigidbody2D rb; // Reference to enemy's Rigidbody2D
    [SerializeField] float minDistance = 2f; // Desired range
    [SerializeField] float deadZone = 0.1f;

    public void TakeDamage(float damage)
    {

        Debug.Log("INIMIGO ATINGIDO! Vida ANTES: " + life + " | Dano recebido: " + damage);

        life -= damage;

        Debug.Log("Vida DEPOIS: " + life);


        // Se a vida chegou a zero ou menos...
        if (life <= 0)
        {
            // 1. Encontra o script do timer na cena.
            HealthTimer timer = FindObjectOfType<HealthTimer>();
            if (timer != null)
            {
                // 2. Adiciona os 2 segundos como recompensa.
                timer.AddTime(2f);
            }
            else
            {
                Debug.LogError("ERRO: HealthTimer não foi encontrado para dar a recompensa!");
            }

            // 3. Destrói o próprio inimigo.
            Destroy(gameObject);
        }
    }

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