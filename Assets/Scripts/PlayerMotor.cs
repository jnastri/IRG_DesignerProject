﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
    public float boost = 1000;
	private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
	private Vector3 thrusterForce = Vector3.zero;

    [SerializeField]
    private float cameraRotationLimit = 85f;

	Rigidbody rb;



	void Start(){
		rb = GetComponent<Rigidbody> ();
	}
		//Gets a movement vector
	public void Move(Vector3 _velocity){
		velocity = _velocity;
	}

	//Gets a rotation vector
	public void Rotate(Vector3 _rotation){
		rotation = _rotation;
	}

	//Gets a rotation vector for the camera
	public void RotateCamera(float _cameraRotationX){
		cameraRotationX = _cameraRotationX;
	}
	// Get force vector for our thrusters
	public void ApplyThruster(Vector3 _thrusterForce){
		thrusterForce = _thrusterForce;
	}

	//Runs every physics iteration
	void Update(){
		PerformMovement ();
		PerformRotation ();

	}

	//Perform movement based on velocity variable
	void PerformMovement(){

		if (velocity != Vector3.zero) {
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);

		}
		if (thrusterForce != Vector3.zero) {
			rb.AddForce (thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
		}

        if (Input.GetButtonDown("Fire2"))
        {
            print("Boost");
            rb.AddForce(velocity * boost, ForceMode.Impulse);
        }
    }


	//Perform rotation
	void PerformRotation(){

		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
		if(cam != null){
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
		}
	}


}
