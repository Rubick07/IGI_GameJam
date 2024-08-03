using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : Enemy
{
    [SerializeField] Transform AttackPos;
    [SerializeField] GameObject BulletProjectile; 
    public float AttackCd;
    public GameObject Gun;
    float AttackCdTemp;
    Player player1;

    private void Start()
    {
        player1 = FindObjectOfType<Player>().GetComponent<Player>();
        AttackCdTemp = AttackCd;
        AttackCd = 0;
    }

    private void FixedUpdate()
    {
        ChasePlayer();
        if (AttackCd > 0)
        {
            AttackCd -= Time.deltaTime;
        }
        else
        {
            AttackCd = 0;
        }

        if (player1 == null)
        {
            Idle();
        }
    }

    private void ChasePlayer()
    {
        if (Vector2.Distance(transform.position, player1.transform.position) <= stats.AttackRadius / 2)
        {

            transform.position = Vector2.MoveTowards(transform.position, -(player1.transform.position) * 1000, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player1.transform.position) <= stats.AttackRadius)
        {
            if (AttackCd <= 0)
            {
                Attack();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, speed * Time.deltaTime);
        }

    }

    private void Attack()
    {
        AttackCd = AttackCdTemp;
        GameObject projectile = Instantiate(BulletProjectile, AttackPos);
        projectile.transform.parent = null;
        EnemyProjectile enemyProjectile = projectile.GetComponent<EnemyProjectile>();
        Vector2 dir = new Vector2(player1.transform.position.x - transform.position.x, player1.transform.position.y - transform.position.y);
        enemyProjectile.damage = stats.Damage;
        enemyProjectile.SetDirectionXY(dir.normalized);
        
    }

    private void Idle()
    {

    }

    public override void Dead()
    {
        CurrencyManager.instance.AddCurrency(Currency);
        GameManager.instance.AddScore(Point);
        int random = Mathf.RoundToInt(Random.Range(0, 101));
        if (random <= 4 && Capsule != null)
        {
            SpawnCapsule();
        }
        else if(random >= 96 && Capsule != null)
        {
            SpawnGun();
        }
        Destroy(gameObject);
    }

    private void SpawnGun()
    {
        GameObject spawn = Instantiate(Gun, transform);
        spawn.transform.parent = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPos.position, stats.AttackRadius);
        Gizmos.DrawWireSphere(AttackPos.position, stats.AttackRadius/2);
    }
}
