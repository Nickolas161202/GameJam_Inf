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

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            return;
        Debug.Log("Bala atingiu algo");
        var damageable = other.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Identificou algo que toma dano!!!");
            damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
