using UnityEngine;

public class ThirdAttack : BaseBossState
{   
    bool canShoot = true;
    private float timer;
    float timeBetweenShoot = 0.1f;
    float bulletspeed = 15;
    public float speed = 3f;
    int shootCount = 0;
    float angle = 15f;
    float currentAngle = 0f;
    public override void EnterState(AttackManager attack)
    {
        Debug.Log("p3 entrada");
    }
    public override void UpdateState(AttackManager attack)
    {
         bossMovement(attack);
        Vector3 bossPos = (Vector3)attack.bossPosition.position;
        bossPos.x += 0.5f; // Adjust for boss width
        bossPos.y -= 0.5f; // Adjust for boss height
        if (canShoot)
        {   float angleRad = currentAngle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            shootCount++;
            canShoot = false;
            timer = 0;
            GameObject bullet = UnityEngine.Object.Instantiate(attack.bossBullet, bossPos, Quaternion.identity);
            currentAngle += angle;
            if (currentAngle >= 360f)   
            {
                currentAngle = 0f; // Reset angle after a full rotation
            }
    
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

        }
        if (shootCount > 300)
        {
            attack.SwitchState(attack.firstAttack);

        }
    }
    public override void OnCollisionEnterState(AttackManager attack)
    {
        
    }
}
