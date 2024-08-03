using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : Interactable
{
    public Secondary weapon;
    public override void Interact()
    {
        Player playeroke = player.GetComponent<Player>();
        playeroke.PickUpWeapon(weapon);   
        Destroy(gameObject);
    }
}
