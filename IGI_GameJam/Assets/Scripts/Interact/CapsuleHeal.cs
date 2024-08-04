using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleHeal : Interactable
{
    public int Heal;
    public override void Interact()
    {
        AudioManager.Instance.PlaySFX("ItemUse");
        Player playeroke = player.GetComponent<Player>();
        playeroke.TakeHeal(Heal);
        Destroy(gameObject);
    }
}
