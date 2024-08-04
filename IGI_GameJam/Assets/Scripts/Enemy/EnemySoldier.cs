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
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player1 = FindObjectOfType<Player>().GetComponent<Player>();
        AttackCdTemp = AttackCd;
        AttackCd = 0;
    }
    private void FixedUpdate()
    {

        if (IsTakeDamage) return;
        if (player1 == null)
        {
            Idle();
            return;
        }
        ChasePlayer();
        Flip();
        if (AttackCd > 0)
        {
            AttackCd -= Time.deltaTime;
        }
        else
        {
            AttackCd = 0;
        }


    }

    private void Idle()
    {
        anim.SetBool("IsWalk", false);
    }

    private void ChasePlayer()
    {
        if(Vector2.Distance(AttackPos.position, player1.transform.position) <= stats.AttackRadius)
        {
            if(AttackCd <= 0)
            {
                StartCoroutine(Attack());
            }
                          
        }
        else
        {
            anim.SetBool("IsWalk", true);
            transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, speed * Time.deltaTime);
        }

    }
    public void Flip()
    {
        if (player1.transform.position.x - transform.position.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (player1.transform.position.x - transform.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }

    private IEnumerator Attack()
    {
        
        speed = 0;
        anim.SetBool("IsAttack", true);
        AttackCd = AttackCdTemp;
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsAttack", false);
        speed = stats.speed;
    }

    public void AttackBeneran()
    {
        AudioManager.Instance.PlaySFX("Robot");
        Collider2D collplayer = Physics2D.OverlapCircle(AttackPos.position, stats.AttackRadius, playerLayer);
        if (collplayer != null)
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
