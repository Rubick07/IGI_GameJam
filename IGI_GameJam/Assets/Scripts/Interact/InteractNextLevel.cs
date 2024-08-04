using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNextLevel : Interactable
{

    public override void Interact()
    {
        AudioManager.Instance.PlaySFX("ItemUse");
        FindObjectOfType<LevelLoader>().GetComponent<LevelLoader>().LoadNextLevel();
    }


}
