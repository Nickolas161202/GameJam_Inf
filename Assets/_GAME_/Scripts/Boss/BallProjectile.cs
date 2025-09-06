using UnityEngine;

public class BallProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private int damage = 5;

    private Rigidbody2D rb;

    void Start()
    {
        // Pega a referência do Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        
        // Destrói a bola após 'lifetime' segundos para não poluir a cena.
        Destroy(gameObject, lifetime);
    }

    // Este método público será chamado pelo Boss para dizer à bola para onde ir.
    public void Launch(Vector2 direction)
    {
        // Adiciona uma força inicial na direção calculada.
        if (rb == null) rb = GetComponent<Rigidbody2D>(); // Garante que o rb foi pego.
        rb.linearVelocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se colidiu com o Player (seu Player precisa ter a tag "Player").
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player foi atingido pela bola!");
            // Aqui você chamaria a função de dano do script do jogador.
            // Ex: collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            
            // Destrói a bola ao atingir o jogador.
            Destroy(gameObject);
        }
        // Opcional: destruir a bola se ela colidir com o cenário
        else if (collision.CompareTag("Wall")) // Use a tag que seu cenário tiver
        {
            Destroy(gameObject);
        }
    }
}