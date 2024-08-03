using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadHunterBullet : Bullet
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
        }
    }

}
