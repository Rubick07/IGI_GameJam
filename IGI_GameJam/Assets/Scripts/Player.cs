using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Stats stats;
    [SerializeField] private LayerMask Enemylayer;
    [SerializeField] private Transform AttackPos;
    private int Hp;
    private float speed;
    Vector2 movement;
    Rigidbody2D rb;
    private void Awake()
    {
        Hp = stats.HP;
        speed = stats.speed;

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Hp <= 0)
        {
            Dead();
        }
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    private void Dash()
    {
        Debug.Log("Dash");
    }

    private void Attack()
    {
        Debug.Log("Attack");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPos.position, stats.AttackRadius, Enemylayer);

        foreach(Collider2D enemy in enemies)
        {
            Enemy enemy1 = enemy.GetComponent<Enemy>();
            enemy1.TakeDamage(stats.Damage);
        }
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
    }

    public void TakeHeal(int heal)
    {
        Hp += heal;
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPos == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPos.position, stats.AttackRadius);
    }

}
