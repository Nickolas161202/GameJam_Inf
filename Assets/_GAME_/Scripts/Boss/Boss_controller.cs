
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AttackManager : MonoBehaviour
{
    BaseBossState currentAttack;
    public FirstAttack firstAttack = new FirstAttack();
    public SecondAttack secondAttack = new SecondAttack();
    public ThirdAttack thirdAttack = new ThirdAttack();


    private Vector2 _moveDir = Vector2.zero;
    [SerializeField] float _moveSpd;
    [SerializeField] Rigidbody2D _rb;


        void Start()
    {

        currentAttack = firstAttack;
        currentAttack.EnterState(this);
    }
    void Update()
    {
        //GetInput();
        currentAttack.UpdateState(this);

    }

    void FixedUpdate()
    {
       // _rb.linearVelocity = _moveDir * _moveSpd * Time.fixedDeltaTime;
    }
        public void SwitchState(BaseBossState currBoss)
    {
        currentAttack = currBoss;
        currentAttack.EnterState(this);
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
