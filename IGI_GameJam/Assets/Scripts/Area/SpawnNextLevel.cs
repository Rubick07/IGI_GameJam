using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextLevel : MonoBehaviour
{
    [SerializeField] InteractNextLevel nextLevel;
    [SerializeField] Transform SpawnPos;

    public void SpawnObject()
    {
        InteractNextLevel level = Instantiate(nextLevel, SpawnPos);
        level.transform.parent = null;
        level.transform.localScale = new Vector3(1, 1, 1);
    }


}
