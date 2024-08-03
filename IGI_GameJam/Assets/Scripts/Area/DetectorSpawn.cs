using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorSpawn : MonoBehaviour
{
    [SerializeField]SpawnMonster[] spawnMonsters;
    [SerializeField] Collider2D[] Barrier;
    [SerializeField] SpawnNextLevel nextLevel;
    [SerializeField] bool LastArea;
    int Banyak;
    bool lewat = false;
    Collider2D barrierini;
    private void Start()
    {
        Banyak = spawnMonsters.Length;
        barrierini = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() && lewat == false)
        {
            Debug.Log("monyet");
            foreach (SpawnMonster spawn in spawnMonsters)
            {
                spawn.SpawnEnemy();
                
            }

            foreach (Collider2D bar in Barrier)
            {
                bar.enabled = true;
                SpriteRenderer spriteRenderer = bar.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = true;
            }
            barrierini.enabled = false;
            lewat = true;
        }
    }

    public void ChildrenDead()
    {
        Banyak--;
        if(Banyak == 0)
        {
            foreach(Collider2D bar in Barrier)
            {
                bar.enabled = false;
                SpriteRenderer spriteRenderer = bar.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = false;
            }

            if (LastArea)
            {
               nextLevel.SpawnObject();
            }
        }
    }
}
