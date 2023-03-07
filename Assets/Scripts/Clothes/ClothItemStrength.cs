using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothItemStrength : ClothItemBase
{
    public float damageMultiplier = 2f;
    public override void Collect()
    {
        base.Collect();
        Player.Instance.healthBase.ChangeDamageMultiplier(damageMultiplier, duration);
    }

 
}
