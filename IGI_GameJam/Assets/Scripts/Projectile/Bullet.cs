using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(int Dir)
    {
        rb.velocity = new Vector2(Dir * speed ,0);        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
