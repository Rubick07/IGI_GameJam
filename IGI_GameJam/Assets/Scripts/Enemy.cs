using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Stats stats;
    private int Hp;
    private float speed;

    private void Awake()
    {
        Hp = stats.HP;
        speed = stats.speed;
    }

    private void Update()
    {
        if(Hp <= 0)
        {
            Dead();
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

}
