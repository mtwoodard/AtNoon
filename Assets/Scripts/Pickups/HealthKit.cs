using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : Item
{
    public int restorationAmount;

    public HealthKit()
    {
        restorationAmount = 25;
    }

    public HealthKit(int healthAmount)
    {
        restorationAmount = healthAmount;
    }

    override public void Use(GameObject player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (stats)
        {
            stats.Health = stats.Health + restorationAmount; // Automatically caps on PlayerStats side.
        }
    }
}