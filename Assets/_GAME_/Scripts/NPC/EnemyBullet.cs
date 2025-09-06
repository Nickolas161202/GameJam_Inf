using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float force;
    [SerializeField] float damage = 1f;

    public Vector2 direction;

    void Start()
    {
        //_rb.linearVelocity = direction.normalized * force;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bala DO INIMIGO atingiu algo");
        // Ignore collision with enemies
        if (other.CompareTag("Enemy"))
            return;

        // Damage player if hit
        var damageable = other.GetComponentInParent<IDamageable>();
        if (other.CompareTag("Player") && damageable != null)
        {
            damageable.TakeDamage(damage);
        }
        // Destroy bullet on any other collision except enemy
        Destroy(gameObject);
    } 
}