
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AttackManager : MonoBehaviour
{
    BaseBossState currentAttack;
    public FirstAttack firstAttack = new FirstAttack();
    public SecondAttack secondAttack = new SecondAttack();
    public ThirdAttack thirdAttack = new ThirdAttack();

        public Transform playerTarget; // Reference to the player's transform
        public Rigidbody2D rb; // Reference to enemy's Rigidbody2D
        public float minDistance = 2f; // Desired range
        public float deadZone = 0.1f;



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
    
    }
        public void SwitchState(BaseBossState currBoss)
    {
        currentAttack = currBoss;
        currentAttack.EnterState(this);
    }




}
