using UnityEngine;

public class FirstAttack : BaseBossState
{
    private Vector3 plPos;
    public float speed = 3f;
    private float timer;
    float timeBetweenShoot =  0.1f;
    float bulletspeed = 20;
    private int shootCount = 0;
    public bool canShoot;
    public override void EnterState(AttackManager attack)
    {
        Debug.Log("p1 entrada");
    }
    public override void UpdateState(AttackManager attack)
    {           
        shootCount++;
        bossMovement(attack);
        Vector3 bossPos = (Vector3)attack.bossPosition.position;
        bossPos.x += 0.5f; // Adjust for boss width
        bossPos.y -= 0.5f; // Adjust for boss height
        if (canShoot)
        {
            timer = 0;
            canShoot = false;
            GameObject bullet = UnityEngine.Object.Instantiate(attack.bossBullet, bossPos, Quaternion.identity);
            Vector2 direction = (attack.playerTarget.position - bossPos).normalized; // <-- changed here
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * bulletspeed;
            }

        }
        else
        {
            timer += Time.fixedDeltaTime;
            if (timer > timeBetweenShoot)
            {
                canShoot = true;
            }

        }if (shootCount > 510)
        {
            attack.SwitchState(attack.secondAttack);
            
        }
        
    }
    public override void OnCollisionEnterState(AttackManager attack)
    {

    }


}
