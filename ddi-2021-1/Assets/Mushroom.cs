using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Mushroom", menuName="Inventory/Consumable")]
public class Mushroom : Item
{
    public float lifeAmount = 5.0f;
    public float effectiveness = 10f;
    public override void Use()
    {
        base.Use();
        // subirme la vida
        Debug.Log($"+ {lifeAmount} HP");
    }
}
