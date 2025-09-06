using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform playerTarget;
    [SerializeField] Transform this_sprite;
    [SerializeField] float shootInterval = 2f;
    [SerializeField] float bulletSpeed = 5f;

    float shootTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            ShootAtPlayer();
            shootTimer = 0f;
        }
    }

    void ShootAtPlayer()
    {
        if (playerTarget == null) return;
        GameObject bullet = Instantiate(bulletPrefab, this_sprite.position, Quaternion.identity);
        Vector2 direction = (playerTarget.position - this_sprite.position).normalized;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }
}
