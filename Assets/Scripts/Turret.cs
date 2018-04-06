using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;

	[Header("Attributes")]
	public float range = 15f;
	public float fireRate = 1f;
	private float fireCountDown = 0f;

	[Header("Unity Setup Fields")]

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public GameObject bulletPrefab;
	public Transform firePoint;



	public string playerTag = "Player";

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			return;
		}

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		if (fireCountDown <= 0f) {
			Shoot ();
			fireCountDown = 1 / fireRate;
		}

		fireCountDown -= Time.deltaTime; 
	}

	void Shoot(){
		GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null) {
			bullet.Seek (target);
		} 
	}

	void UpdateTarget(){
		GameObject[] players = GameObject.FindGameObjectsWithTag (playerTag);

		float shortestDistance = Mathf.Infinity;
		GameObject nearestPlayer = null;

		foreach (GameObject player in players) {
			float distanceToPlayer = Vector3.Distance (transform.position, player.transform.position);
			if (distanceToPlayer < shortestDistance)
			{
				shortestDistance = distanceToPlayer;
				nearestPlayer = player;
			}
		}

		if (nearestPlayer != null && shortestDistance <= range) {
			target = nearestPlayer.transform;

		
		} else {
			target = null;
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
