using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Bullet
{

    public void SetDirectionXY(Vector2 Arah)
    {
        rb.velocity = new Vector2(Arah.x * speed, Arah.y * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
