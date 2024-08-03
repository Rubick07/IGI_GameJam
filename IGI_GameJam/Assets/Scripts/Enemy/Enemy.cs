using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Stats stats;
    public LayerMask playerLayer;
    public int Currency;
    public int Hp;
    public float speed;
    public int droprate;
    public int Point = 100;
    public GameObject Capsule;
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

    public virtual void Dead()
    {
        CurrencyManager.instance.AddCurrency(Currency);
        GameManager.instance.AddScore(Point);
        int random = Mathf.RoundToInt(Random.Range(0,101));
        if(random <= 4 && Capsule != null)
        {
            SpawnCapsule();
        }
        Destroy(gameObject);
    }

    public virtual void SpawnCapsule()
    {
      GameObject spawn = Instantiate(Capsule, transform);
      spawn.transform.parent = null;
    }

}
