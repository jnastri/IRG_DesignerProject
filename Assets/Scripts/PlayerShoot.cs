using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public PlayerWeapon weapon;

	[SerializeField]
	private LayerMask mask;

	[SerializeField]
	private Camera cam;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			Debug.LogError ("PlayerShoot: No camera referenced");
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
		}
	}

	void Shoot(){
		RaycastHit _hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask)) {
			Debug.Log ("We hit" + _hit.collider.name);
		}
	}

}
