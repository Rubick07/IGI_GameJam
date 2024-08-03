using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleEnergy : Interactable
{
    public int Energy;
    public override void Interact()
    {
        Player playeroke = player.GetComponent<Player>();
        playeroke.AddEnergy(Energy);
        Destroy(gameObject);
    }

}
