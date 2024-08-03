using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStrikeBullet : Bullet
{
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] float ExplosionRadius;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius, EnemyLayer);

            foreach (Collider2D enemy in enemies)
            {
                Enemy enemy1 = enemy.GetComponent<Enemy>();
                enemy1.TakeDamage(damage);
            }

            Destroy(gameObject);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }


}
