using UnityEngine;

public class ThirdAttack : BaseBossState
{
    public override void EnterState(AttackManager attack)
    {
        Debug.Log("p3 entrada");
    }
    public override void UpdateState(AttackManager attack)
    {
        attack.SwitchState(attack.firstAttack);
    }
    public override void OnCollisionEnterState(AttackManager attack)
    {
        
    }
}
