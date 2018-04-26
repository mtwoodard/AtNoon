using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : System.Object
{
    public float damage = 10f;
    public float range = 100f;

    public int magazineSize = 6;
    public int maxAmmoCarry = -1;
}
