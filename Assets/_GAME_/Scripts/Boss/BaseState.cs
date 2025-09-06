using UnityEngine;
using System.Collections.Generic;

public abstract class BaseBossState
{
    public abstract void EnterState(AttackManager  attack);
    public abstract void UpdateState(AttackManager attack);
    public abstract void OnCollisionEnterState(AttackManager attack);
}
