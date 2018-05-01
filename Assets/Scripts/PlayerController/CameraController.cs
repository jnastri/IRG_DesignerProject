using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";

    public GameObject Pivot;
    public GameObject Lever;

    public float MouseSensitivity = 150;
    public float MaxLookUp = -0.2f;
    public float MaxLookDown = 0.2f;

    private bool IsRotatingCharacter = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        float h = MouseSensitivity * Input.GetAxis(MOUSE_X) * Time.deltaTime;
        float v = -MouseSensitivity * Input.GetAxis(MOUSE_Y) * Time.deltaTime;

        if (IsRotatingCharacter)
            transform.Rotate(0, h, 0);
        else
            Pivot.transform.Rotate(0, h, 0);

        Lever.transform.Rotate(v, 0, 0);

        RotationClamping();
    }


    private void RotationClamping()
    {
        if (Lever.transform.localRotation.x > MaxLookDown)
        {
            Lever.transform.localRotation = new Quaternion(MaxLookDown, 0, 0, Lever.transform.localRotation.w);
        }
        else if (Lever.transform.localRotation.x < MaxLookUp)
        {
            Lever.transform.localRotation = new Quaternion(MaxLookUp, 0, 0, Lever.transform.localRotation.w);
        }
    }

    public void EnableBodyRotation()
    {
        //Pivot.transform.localRotation = Quaternion.Euler(Vector3.zero);
        IsRotatingCharacter = true;
    }

    public void DisableBodyRotation()
    {

        IsRotatingCharacter = false;
    }

    public void EnableWiderAngle()
    {
        MaxLookUp = -0.6f;
        MaxLookDown = 0.8f;
    }

    public void DisableWiderAngle()
    {
        MaxLookUp = -0.2f;
        MaxLookDown = 0.2f;

    }
}
