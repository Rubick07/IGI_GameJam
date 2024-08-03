using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public Enemy enemy;
    [SerializeField] Enemy EnemyIni;
    public bool IsDead;
    
    public void SpawnEnemy()
    {
       EnemyIni = Instantiate(enemy, transform);
        EnemyIni.transform.SetParent(transform.parent);
    }

}
