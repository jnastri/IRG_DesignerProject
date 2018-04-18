using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultController : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";
    private const string SPEED = "Speed";

    public float Speed = 8;
    public float MouseSensitivity = 150;
    public float MaxLookUp = 0.6f;
    public float MaxLookDown = 0.65f;

    public float Speedometer = 0;

    public GameObject Head;
    public GameObject Body;
    public Animator Animator;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Animator = Body.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }

    void FixedUpdate()
    {

    }

    private void UpdateRotation()
    {
        float h = MouseSensitivity * Input.GetAxis(MOUSE_X) * Time.deltaTime;
        float v = -MouseSensitivity * Input.GetAxis(MOUSE_Y) * Time.deltaTime;

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
        float horizontal;
        float vertical;
        Vector3 positionChange;

        GetInputFromKeyboard(out horizontal, out vertical, out positionChange);

        UpdateModelOrientation(horizontal, vertical, positionChange);
        ClampSidewaysSpeed(ref positionChange);
        transform.position += positionChange;

        Speedometer = positionChange.magnitude;
        Animator.SetFloat(SPEED, Speedometer);

    }

    private void GetInputFromKeyboard(out float horizontal, out float vertical, out Vector3 positionChange)
    {
        horizontal = Input.GetAxis(HORIZONTAL_AXIS);
        vertical = Input.GetAxis(VERTICAL_AXIS);
        positionChange = transform.right * horizontal * Time.deltaTime * Speed;
        positionChange += transform.forward * vertical * Time.deltaTime * Speed;
    }

    private void ClampSidewaysSpeed(ref Vector3 positionChange)
    {
        positionChange = Vector3.ClampMagnitude(positionChange, Time.deltaTime * Speed);
    }

    private void UpdateModelOrientation(float horizontal, float vertical, Vector3 positionChange)
    {
        if (horizontal != 0 || vertical != 0)
        {
            positionChange += Body.transform.position;
            positionChange.y = Body.transform.position.y;
            Body.transform.LookAt(positionChange);
        }
    }
}
