using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player_controller : MonoBehaviour, IDamageable
{
    private Vector2 _moveDir = Vector2.zero;
    [SerializeField] float _moveSpd;
    [SerializeField] float timeToRemove = 1.0f;
    [SerializeField] Rigidbody2D _rb;

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = _moveDir * _moveSpd * Time.fixedDeltaTime;
    }

    public void GetInput()
    {

        //if w, go up, if s, go down, if a, go left, if d, go right
        _moveDir = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) _moveDir.y += 1;
        if (Input.GetKey(KeyCode.S)) _moveDir.y -= 1;
        if (Input.GetKey(KeyCode.D)) _moveDir.x += 1;
        if (Input.GetKey(KeyCode.A)) _moveDir.x -= 1;


    }

    public void TakeDamage(float damage)
    {
        HealthTimer timer = FindObjectOfType<HealthTimer>();
            if (timer != null)
            {
                // 2. Adiciona os 2 segundos como recompensa.
                timer.RemoveTime(timeToRemove);
            }
            else
            {
                Debug.LogError("ERRO: HealthTimer não foi encontrado para dar a recompensa!");
            }

    }

}
