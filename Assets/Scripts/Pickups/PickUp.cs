using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public enum Type
    {
        HEALTH,
        AMMO
    }

    public Type type;

    public float respawnDelay;
    private float respawnTime;

    protected Item effect;
    protected bool active;

	// Use this for initialization
	void Start ()
    {
        active = true;

	    switch(type)
        {
            case Type.HEALTH:
                effect = new HealthKit();
                break;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Time.time > respawnTime)
        {
            active = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
	}


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);

        if(!active)
        {
            return;
        }

        if(collision.gameObject.GetComponent<PlayerStats>())
        {
            effect.Use(collision.gameObject);
        }

        Debug.Log(collision.gameObject.GetComponent<PlayerStats>().Health);
        active = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        respawnTime = respawnDelay + Time.time;
    }
}
