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
        Debug.Log("Bala colidiu com o objeto: " + other.name);

    
            // 3. A bala cumpriu seu papel, então ela se destrói.
            //Destroy(gameObject);

}
}
