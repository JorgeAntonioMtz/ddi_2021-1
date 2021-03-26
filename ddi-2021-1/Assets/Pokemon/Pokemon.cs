using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokemonType
{
    Fire, Electric, Water, Grass
}

[CreateAssetMenu(fileName= "New Pokemon", menuName="Inventory/Pokemon")]
public class Pokemon : Item
{
    public PokemonType pokemonType = PokemonType.Fire;

    /*public override void Use()
    {
        base.Use();
        Debug.Log("Este es un Pokémon");
    }*/
}
