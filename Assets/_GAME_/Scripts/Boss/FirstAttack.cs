using UnityEngine;

public class FirstAttack : BaseBossState
{
    public override void EnterState(AttackManager attack)
    {
        Debug.Log("p1 entrada");
    }
    public override void UpdateState(AttackManager attack)
    {
        attack.SwitchState(attack.secondAttack);
    }
    public override void OnCollisionEnterState(AttackManager attack)
    {

    }
}
