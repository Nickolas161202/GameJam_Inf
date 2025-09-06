using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Vector3 mousePos;
    Camera mainCam;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float force;

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
    {   Debug.Log("Hit tag: " + other.tag); // log the tag of whatever we hit

        if (!other.CompareTag("Player")) // mais rápido e limpo
        {
            Destroy(gameObject);
        }
        else
        {
            
        }
    
    }
}
