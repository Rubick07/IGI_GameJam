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
    public bool IsTakeDamage;
    public float TimeKnockBack;

    public Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
        if(IsTakeDamage == true)
        {
            return;
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

    public virtual IEnumerator TakeDamageKnockBack(int damage, Transform transformPlayer)
    {
        Hp -= damage;
        IsTakeDamage = true;
        Vector2 dir = new Vector2(transformPlayer.position.x - transform.position.x, transformPlayer.position.y - transform.position.y);
        rb.AddForce(-(dir.normalized) * 3.5f, ForceMode2D.Impulse);
        Debug.Log(dir.normalized);
        yield return new WaitForSeconds(TimeKnockBack);
        rb.velocity = Vector2.zero;
        IsTakeDamage = false;
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
