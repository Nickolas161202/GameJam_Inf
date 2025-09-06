using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Boss_controller : MonoBehaviour
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
        //ARROWS
        _moveDir = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow)) _moveDir.y += 1;
        if (Input.GetKey(KeyCode.DownArrow)) _moveDir.y -= 1;
        if (Input.GetKey(KeyCode.RightArrow)) _moveDir.x += 1;
        if (Input.GetKey(KeyCode.LeftArrow)) _moveDir.x -= 1;
    }


}
