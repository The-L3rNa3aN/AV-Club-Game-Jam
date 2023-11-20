using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int healthCount;

    public void StartHealth()
    {
        //Add logic.
    }

    public void Heal(int number)
    {
        healthCount += number;
    }

    public void Damage(int number)
    {
        healthCount -= number;

        if(healthCount <= 0)
          KillEntity();
    }

    public void KillEntity()
    {
        //Kill the entity.
    }
}
