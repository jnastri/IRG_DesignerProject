using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultController : MonoBehaviour
{
 
    

    public float Speedometer = 0;

    public GameObject Body;
    public Animator Animator;

    public Vector3 PositionChangeClamped;

    ControllerSettings Settings;
    // Use this for initialization
    void Start()
    {
        Settings = GetComponent<ControllerSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    void FixedUpdate()
    {

    }
    

    private void UpdateMovement()
    {
        float horizontal;
        float vertical;

        GetInputFromKeyboard(out horizontal, out vertical, out PositionChangeClamped);

        UpdateModelOrientation(horizontal, vertical, PositionChangeClamped);
        ClampSidewaysSpeed(ref PositionChangeClamped);
        transform.position += PositionChangeClamped;

        Speedometer = PositionChangeClamped.magnitude;
        Animator.SetFloat(ControllerSettings.SPEED, PositionChangeClamped.magnitude);
    }

    private void GetInputFromKeyboard(out float horizontal, out float vertical, out Vector3 positionChange)
    {
        horizontal = Input.GetAxis(ControllerSettings.HORIZONTAL_AXIS);
        vertical = Input.GetAxis(ControllerSettings.VERTICAL_AXIS);
        positionChange = transform.right * horizontal * Time.deltaTime * Settings.Speed;
        positionChange += transform.forward * vertical * Time.deltaTime * Settings.Speed;
    }

    private void ClampSidewaysSpeed(ref Vector3 positionChange)
    {
        positionChange = Vector3.ClampMagnitude(positionChange, Time.deltaTime * Settings.Speed);
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
