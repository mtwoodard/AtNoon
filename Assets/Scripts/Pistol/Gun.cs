using UnityEngine;

public class Gun : MonoBehaviour {
    
	public Camera cam;
	public ParticleSystem muzzleFlash;

    public Weapon currentWeapon;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {

		if(Input.GetButtonDown("Fire1")) {
			Shoot();
		}
	}
	void Shoot () {
		//muzzleFlash.Play ();

		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, currentWeapon.range)) {
			Debug.Log (hit.transform.name);

			Enemy enemy = hit.transform.GetComponent<Enemy> ();
			if (enemy != null) {
				enemy.TakeDamage (currentWeapon.damage);
			}
		}
	}
}
