using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultController : MonoBehaviour {

    public float Speed = 8;
    public float MouseSensitivity = 150;
    public float MaxLookUp = 0.6f;
    public float MaxLookDown = 0.65f;
    public GameObject Head;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateMovement();
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        float h = MouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        float v = -MouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

        transform.Rotate(0, h, 0);
        Head.transform.Rotate(v, 0, 0);

        RotationClamping();
    }

    private void RotationClamping()
    {
        if (Head.transform.localRotation.x > MaxLookDown)
        {
            Head.transform.localRotation = new Quaternion(MaxLookDown, 0, 0, Head.transform.localRotation.w);
        }
        else if (Head.transform.localRotation.x < MaxLookUp)
        {
            Head.transform.localRotation = new Quaternion(MaxLookUp, 0, 0, Head.transform.localRotation.w);
        }
    }

    private void UpdateMovement()
    {
        transform.position += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        transform.position += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * Speed;
    }
}
