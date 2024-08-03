using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : Enemy
{
    public enum State {Idle, Run, Attack}
    [SerializeField] Transform AttackPos;
    public State state;
    public float AttackCd;
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

    private void Idle()
    {
        
    }

    private void ChasePlayer()
    {
        if(Vector2.Distance(AttackPos.position, player1.transform.position) <= stats.AttackRadius)
        {
            if(AttackCd <= 0)
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
        Debug.Log("Attack");
        AttackCd = AttackCdTemp;
        Collider2D collplayer = Physics2D.OverlapCircle(AttackPos.position, stats.AttackRadius, playerLayer);
        if(collplayer != null)
        {
            Player player = collplayer.gameObject.GetComponent<Player>();
            player.TakeDamage(stats.Damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPos.position, stats.AttackRadius);
    }

}
