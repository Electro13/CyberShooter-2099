using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHealthSystem
{
    private int health;

    public SpaceHealthSystem(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
    }
}
