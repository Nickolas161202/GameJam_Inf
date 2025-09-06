using UnityEngine;

public class SecondAttack : BaseBossState
{
    bool canShoot = true;
    private float timer;
    float timeBetweenShoot = 0.1f;
    float bulletspeed = 15;
    public float speed = 3f;
    int shootCount = 0;
    public override void EnterState(AttackManager attack)
    {
        Debug.Log("p2 entrada");
    }
    public override void UpdateState(AttackManager attack)
    {

        bossMovement(attack);
        Vector3 bossPos = (Vector3)attack.bossPosition.position;
        bossPos.x += 0.5f; // Adjust for boss width
        bossPos.y -= 0.5f; // Adjust for boss height
        if (canShoot)
        {
            shootCount++;
            canShoot = false;
            timer = 0;
            GameObject bullet = UnityEngine.Object.Instantiate(attack.bossBullet, bossPos, Quaternion.identity);
            Vector2 direction; // <-- changed here
            direction.x = Random.Range(-1f, 1f);
            direction.y = Random.Range(-1f, 1f);
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
            attack.SwitchState(attack.thirdAttack);

        }
    }
    public override void OnCollisionEnterState(AttackManager attack)
    {
        
    }
}
