using UnityEngine;

public class BossBullet : MonoBehaviour
{
    Vector3 mousePos;
    Camera mainCam;
    private Rigidbody2D _rb;
    [SerializeField] float force;
    [SerializeField] float damage = 1f;
    [SerializeField] Transform playerTarget;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
    }



    // Update is called once per frame
    void Update()
    {
        //se matou o inimigo, aumentar 2 segundos no tempo do jogo.


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
