using UnityEngine;
using System.Collections.Generic;

public abstract class BaseBossState
{
    public abstract void EnterState(AttackManager attack);
    public abstract void UpdateState(AttackManager attack);
    public abstract void OnCollisionEnterState(AttackManager attack);

    public void bossMovement(AttackManager attack)
    {
        if (attack.playerTarget != null && attack.rb != null)
            {
                float distance = Vector2.Distance(attack.rb.position, attack.playerTarget.position);
            if (distance > attack.minDistance)
            {
                Vector2 targetPosition = Vector2.MoveTowards(attack.rb.position, (Vector2)attack.playerTarget.position, attack.speed * Time.fixedDeltaTime);
                attack.rb.MovePosition(targetPosition);
            }
            else if (distance < attack.minDistance - attack.deadZone)
            {
                // Move away from the player to stay within range
                Vector2 directionAway = (attack.rb.position - (Vector2)attack.playerTarget.position).normalized;
                Vector2 moveAwayPosition = attack.rb.position + directionAway * attack.speed * Time.fixedDeltaTime;
                attack.rb.MovePosition(moveAwayPosition);
            }
        }   
    }
}
