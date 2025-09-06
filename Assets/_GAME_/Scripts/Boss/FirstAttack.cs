using UnityEngine;

public class FirstAttack : BaseBossState
{
    public float speed = 3f;
    public override void EnterState(AttackManager attack)
    {
        Debug.Log("p1 entrada");
    }
    public override void UpdateState(AttackManager attack)
    {
            if (attack.playerTarget != null && attack.rb != null)
            {   
                float distance = Vector2.Distance(attack.rb.position, attack.playerTarget.position);
                if (distance > attack.minDistance)
                {
                    Vector2 targetPosition = Vector2.MoveTowards(attack.rb.position, (Vector2)attack.playerTarget.position, speed * Time.fixedDeltaTime);
                    attack.rb.MovePosition(targetPosition);
                }
                else if (distance < attack.minDistance - attack.deadZone)
                {
                    // Move away from the player to stay within range
                    Vector2 directionAway = (attack.rb.position - (Vector2)attack.playerTarget.position).normalized;
                    Vector2 moveAwayPosition = attack.rb.position + directionAway * speed * Time.fixedDeltaTime;
                    attack.rb.MovePosition(moveAwayPosition);
                }
            }
    }
    public override void OnCollisionEnterState(AttackManager attack)
    {

    }
}
