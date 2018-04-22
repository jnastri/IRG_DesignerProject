using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";

    public GameObject Head;

    public float MouseSensitivity = 150;
    public float MaxLookUp = -0.2f;
    public float MaxLookDown = 0.2f;
    public bool IsRotatingCharacter = true;
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
            Head.transform.Rotate(0, h, 0);
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
}
