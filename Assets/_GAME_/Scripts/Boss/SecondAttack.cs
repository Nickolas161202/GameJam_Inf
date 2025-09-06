using UnityEngine;

public class SecondAttack : BaseBossState
{
    public override void EnterState(AttackManager attack)
    {
        Debug.Log("p2 entrada");
    }
    public override void UpdateState(AttackManager attack)
    {
        attack.SwitchState(attack.thirdAttack);
    }
    public override void OnCollisionEnterState(AttackManager attack)
    {
        
    }
}
