using UnityEngine;
[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5.0f;
	[SerializeField]
	private float lookSensitivity = 3f;
    [HideInInspector]
    public bool isGrounded;
    

	[SerializeField]
	private float thrusterForce = 1000f;

	/*[Header("Joint Options:")]
	[SerializeField]
	private JointDriveMode jointMode = JointDriveMode.Position;
	[SerializeField]
	private float jointSpring = 20f;
	[SerializeField]
	private float jointMaxForce = 40f; */

	private PlayerMotor motor;
	//private ConfigurableJoint joint;

	void Start(){
		motor = GetComponent<PlayerMotor> ();
		//joint = GetComponent<ConfigurableJoint> ();
		//SetJointSettings (jointSpring);


}

	void Update(){
		//Calculate movement velocity as a 3d vector
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMove = Input.GetAxisRaw ("Vertical");

		Vector3 _moveHorizontal = transform.right * _xMov; 
		Vector3 _moveVertical = transform.forward * _zMove; 

		Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

		//Apply movement
		motor.Move(_velocity);

		//Calculate rotation as a 3d Vector. 
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

		//Apply rotation
		motor.Rotate(_rotation);

		//Calculate camera rotation as a 3d Vector. 
		float _xRot = Input.GetAxisRaw("Mouse Y");

		float _cameraRotationX = _xRot * lookSensitivity;

		//Apply camera rotation
		motor.RotateCamera(_cameraRotationX);

		//Calculate thruster force based on player input.
		Vector3 _thrusterForce = Vector3.zero;


		if(Input.GetButton("Jump") && isGrounded){
			_thrusterForce = Vector3.up * thrusterForce;
			//SetJointSettings (0f);
		}
		//apply thruster force
		motor.ApplyThruster (_thrusterForce);
	}

/*	private void SetJointSettings(float _jointSpring)
	{
		joint.yDrive = new JointDrive{ 
			mode = jointMode,
			positionSpring = _jointSpring, 
			maximumForce = jointMaxForce};
	}*/
}
