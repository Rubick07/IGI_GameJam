using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : Interactable
{
    public Secondary weapon;
    public override void Interact()
    {
        AudioManager.Instance.PlaySFX("ItemUse");
        Player playeroke = player.GetComponent<Player>();
        playeroke.PickUpWeapon(weapon);   
        Destroy(gameObject);
    }
}
