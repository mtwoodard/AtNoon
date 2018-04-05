using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public Camera cam;
	public ParticleSystem muzzleFlash;
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1")) {
			Shoot();
		}
	}
	void Shoot () {
		//muzzleFlash.Play ();

		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.name);

			Enemy enemy = hit.transform.GetComponent<Enemy> ();
			if (enemy != null) {
				enemy.TakeDamage (damage);
			}
		}
	}
}
