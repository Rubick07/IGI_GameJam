using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Attribute")]
    [SerializeField] private Stats stats;
    private Secondary SecondaryWeapon;
    private int Hp;
    private float speed;
    private int Defense;
    Vector2 movement;
    Rigidbody2D rb;


    public enum Stance {Melee, range}
    public Stance stance;
    [Header("Interact Set Up")]
    [SerializeField] private float InteractRange;
    [SerializeField] private LayerMask ItemLayer;

    [Header("Dash Attribute")]
    //buat dash
    bool Candash;
    bool ISdashing;
    [SerializeField] private int DashCost;
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime;
    [SerializeField] private float dashingCooldown = 1;
    float dashingCooldownTemp = 1f;
    TrailRenderer trail;

    [Header("Player Melee SetUp")]
    [SerializeField] private int BulletEnergyCost;
    [SerializeField] private GameObject BulletEnergy;
    [SerializeField] private float BulletEnergycd;
    float BulletEnergycdTemp;
    bool CanEnergyStrike;

    [SerializeField] private LayerMask Enemylayer;
    [SerializeField] private Transform AttackPos;
    [SerializeField] private int UltimateCost;
    [SerializeField] private int Ultimatedamage;
    [SerializeField] private float UltimateRange;
    [SerializeField] private float Ultimatecd;
    float UltimatecdTemp;
    bool CanUltimate;

    [Header("Player Range SetUP")]
    [SerializeField] private GameObject BulletNormal;
    [SerializeField] private int HeadHunterCost;
    [SerializeField] private GameObject BulletHeadhunter;
    [SerializeField] private float HeadHuntercd;    
    float HeadHuntercdTemp;
    bool CanHeadHunter;

    [SerializeField] private int BurstAmount;
    [SerializeField] private float IntervalShoot;
    bool IsShooting = false;

    //Energy
    private int Energy = 0;
    private int MaxEnergy = 100;

    [Header("Pause SetUp")]
    [SerializeField] Button PauseButton;
    [Header("Animator SetUp")]
    [SerializeField]Animator anim;
    private void Awake()
    {
        Hp = stats.HP;
        speed = stats.speed;
        Defense = stats.Defense;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        HeadHuntercdTemp = HeadHuntercd;
        BulletEnergycdTemp = BulletEnergycd;
        UltimatecdTemp = Ultimatecd;
        InvokeRepeating("PassiveEnergy", 0, 1f);
    }

    private void Update()
    {
        if (Hp <= 0)
        {
            Dead();
        }
        CooldownFunction();

        if (IsShooting)
        {
            return;
        }
        PlayerMovement();
    }

    private void CooldownFunction()
    {
        if (dashingCooldownTemp > 0)
        {
            dashingCooldownTemp -= Time.deltaTime;
        }
        if (dashingCooldownTemp <= 0)
        {
            dashingCooldownTemp = 0;
            Candash = true;
        }

        if(HeadHuntercd > 0)
        {
            HeadHuntercd -= Time.deltaTime;
        }
        if(HeadHuntercd <= 0)
        {
            HeadHuntercd = 0;
            CanHeadHunter = true;
        }

        if(BulletEnergycd > 0)
        {
            BulletEnergycd -= Time.deltaTime;
        }
        if(BulletEnergycd <= 0)
        {
            BulletEnergycd = 0;
            CanEnergyStrike = true;
        }

        if(Ultimatecd > 0)
        {
            Ultimatecd -= Time.deltaTime;
        }
        if(Ultimatecd <= 0)
        {
            Ultimatecd = 0;
            CanUltimate = true;
        }
    }

    private void FixedUpdate()
    {
        if (ISdashing)
        {
            return;
        }
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
    #region Player
    private void PlayerMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Movement", Mathf.Max(Mathf.Abs(movement.x), Mathf.Abs(movement.y)));
        SpriteController();

        //Player Input
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            SwitchStance();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Candash && CheckEnergy(DashCost))
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Skill();
        }
        if (Input.GetKeyDown(KeyCode.Q) && CanUltimate && CheckEnergy(UltimateCost))
        {
            Ultimate();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Collider2D item = Physics2D.OverlapCircle(transform.position, InteractRange, ItemLayer);

        if(item != null)
        {
            Interactable barang = item.GetComponent<Interactable>();
            barang.Interact();
        }

    }

    private void SwitchStance()
    {
        if(stance == Stance.Melee && SecondaryWeapon != null)
        {
            stance = Stance.range;
        }
        else if(stance == Stance.range)
        {
            stance = Stance.Melee;
        }
    }

    private void SpriteController()
    {
        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    #region SpecialSkill
    public void Ultimate()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPos.position, UltimateRange, Enemylayer);

        foreach (Collider2D enemy in enemies)
        {
            Enemy enemy1 = enemy.GetComponent<Enemy>();
            enemy1.TakeDamage(Ultimatedamage);
        }
        Ultimatecd = UltimatecdTemp;
        CanUltimate = false;
        MinusEnergy(UltimateCost);
    }

    public void Skill()
    {
       IsShooting = true;
       speed = 0;
       if(stance == Stance.Melee && CanEnergyStrike && CheckEnergy(BulletEnergyCost))
       {
            EnergyStrikeBullet();
       }
       else if(stance == Stance.range && CanHeadHunter && CheckEnergy(HeadHunterCost))
       {
            HeadHunter();
       }
       IsShooting = false;
       speed = stats.speed;
    }

    private void EnergyStrikeBullet()
    {
        ShootBullet(BulletEnergy);
        MinusEnergy(BulletEnergyCost);
        CanEnergyStrike = false;
        BulletEnergycd = BulletEnergycdTemp;
    }

    private void HeadHunter()
    {
        ShootBullet(BulletHeadhunter);
        MinusEnergy(HeadHunterCost);
        CanHeadHunter = false;
        HeadHuntercd = HeadHuntercdTemp;
    }
    #endregion


    public void Attack()
    {
        if(stance == Stance.Melee)
        {
            Debug.Log("Attack");
            Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPos.position, stats.AttackRadius, Enemylayer);

            foreach(Collider2D enemy in enemies)
            {
                Enemy enemy1 = enemy.GetComponent<Enemy>();
                enemy1.TakeDamage(stats.Damage);
            }
        }
        else if(stance == Stance.range)
        {
            IsShooting = true;
            speed = 0;
            StartCoroutine(Shoot());            
            
        }
    }
    private IEnumerator Dash()
    {
        MinusEnergy(DashCost);
        Candash = false;
        dashingCooldownTemp = dashingCooldown;
        ISdashing = true;
        Vector2 DashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = DashingDir.normalized * dashingPower;
        trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trail.emitting = false;
        ISdashing = false;
    }
    private IEnumerator Shoot()
    {
        for(int i = 0; i < BurstAmount; i++)
        {
            ShootBullet(BulletNormal);
            yield return new WaitForSeconds(IntervalShoot);
        }
        IsShooting = false;
        speed = stats.speed;
    }

    private void ShootBullet(GameObject BulletdiTembak)
    {
        if(SecondaryWeapon.Ammo == 0)
        {
            stance = Stance.Melee;
            return;
        }
        if(BulletdiTembak == BulletNormal)
        {
            SecondaryWeapon.Ammo--;
        }
        GameObject bullet = Instantiate(BulletdiTembak, AttackPos);
        bullet.transform.parent = null;
        Bullet rbbullet = bullet.GetComponent<Bullet>();
        if (transform.eulerAngles.y == 0)
        {
            rbbullet.SetDirection(1);
        }
        else
        {
            rbbullet.SetDirection(-1);
        }
    }

    public void PickUpWeapon(Secondary weapon)
    {
        if(SecondaryWeapon != null)
        {
            Secondary temp = SecondaryWeapon;
            SecondaryWeapon = weapon;
        }
        else
        {
            SecondaryWeapon = weapon;
        }
    }

    #endregion
    #region PlayerHealth

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
    #endregion
    #region Energy

    public void AddEnergy(int energy)
    {
        Energy += energy;
        Energy = Mathf.Clamp(Energy, 0, MaxEnergy);
    }

    public void MinusEnergy(int energy)
    {
        Energy -= energy;
        Energy = Mathf.Clamp(Energy, 0, MaxEnergy);
    }

    public void PassiveEnergy()
    {
        AddEnergy(2);
    }

    public bool CheckEnergy(int banyak)
    {
        if (Energy >= banyak)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    void OnDrawGizmosSelected()
    {
        if (AttackPos == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPos.position, stats.AttackRadius);
        Gizmos.DrawWireSphere(AttackPos.position, UltimateRange);
        Gizmos.DrawWireSphere(transform.position, InteractRange);
    }

}
