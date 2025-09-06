using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Vector3 mousePos;
    Camera mainCam;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float force;
    [SerializeField] float damage = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        _rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
    }



    // Update is called once per frame
    void Update()
    {
        //se matou o inimigo, aumentar 2 segundos no tempo do jogo.


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bala colidiu com o objeto: " + other.name);

        // Verifica se atingiu um inimigo
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Inimigo atingido pela bala!");
            // 1. Pega o script do inimigo que foi atingido.
            EnemyFollow enemy = other.GetComponent<EnemyFollow>();
            if (enemy != null)
            {
                Debug.Log("Inimigo tem o script EnemyFollow, aplicando dano.");
                // 2. Chama o método do inimigo para ele receber o dano.
                enemy.TakeDamage(damage);
                Debug.Log("Dano aplicado: " + damage);
            }

            // 3. A bala cumpriu seu papel, então ela se destrói.
            Destroy(gameObject);
        }
        // Se atingiu qualquer outra coisa que não seja o Player, a bala também se destrói.
        else if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
