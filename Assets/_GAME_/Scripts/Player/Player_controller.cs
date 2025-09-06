using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player_controller : MonoBehaviour
{
    private Vector2 _moveDir = Vector2.zero;
    [SerializeField] float _moveSpd;
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
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
    }


}
