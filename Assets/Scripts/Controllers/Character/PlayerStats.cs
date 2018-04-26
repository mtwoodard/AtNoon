using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    protected int health = 50;
    public const int MAX_HEALTH = 100;

    public int Health
    {
        get { return health; }
        set { health = Mathf.Min(MAX_HEALTH, value); }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
