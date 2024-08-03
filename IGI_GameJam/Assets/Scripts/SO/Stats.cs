using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Stats")]
public class Stats : ScriptableObject
{
    public int HP;
    public int Damage;
    public int Defense;
    public float speed;
    public float AttackRadius;

}
