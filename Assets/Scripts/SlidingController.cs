using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingController : MonoBehaviour
{

    public Animator Animator;
    public GameObject Body;

    public DefaultController DefaultController;

    public float Friction = 0.01f;
    public float MinimumSpeed = 0.3f;
    public float endTime;

    ControllerSettings Settings;
    Vector3 initialPosition;
    Quaternion initialRotation;
    Vector3 terminalPosition;
    Quaternion terminalRotation;
    float startTime;
    Vector3 positionChange;
    bool exiting;
    // Use this for initialization
    void Start()
    {

    }


    void OnEnable()
    {
        Animator.SetBool("IsSliding", true);
        Settings = GetComponent<ControllerSettings>();
        positionChange = DefaultController.PositionChangeClamped;
        initialPosition = Body.transform.localPosition;
        initialRotation = Body.transform.localRotation;
        terminalPosition = new Vector3(initialPosition.x - 0.36733071f, initialPosition.y - 0.893f, initialPosition.z - -0.6970924f);
        terminalRotation = initialRotation * Quaternion.Euler(-28.975f, 4.481f, -17.897f);
        startTime = Time.time;
        GetComponent<CameraController>().IsRotatingCharacter = false;
        exiting = false;
    }

    void Disable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (positionChange.magnitude > MinimumSpeed )
        {
            transform.position += positionChange;
            positionChange -= DefaultController.PositionChangeClamped * Friction;
        }

        if ((Time.time - startTime) > 0.5f && (positionChange.magnitude < MinimumSpeed 
            || exiting 
            || Input.GetAxis(ControllerSettings.SLIDE) == 0
            ))
        {
            exiting = true;
            StartCoroutine(SlideOut());
            return;
        }
        Body.transform.localPosition = Vector3.Lerp(Body.transform.localPosition, terminalPosition, Time.deltaTime * 7);
        Body.transform.localRotation = Quaternion.Lerp(Body.transform.localRotation, terminalRotation, Time.deltaTime * 7);


    }

    IEnumerator SlideOut()
    {
        Animator.SetBool("IsSliding", false);

        while (Vector3.Distance(Body.transform.localPosition, initialPosition) > 0.01f)
        {
            Body.transform.localPosition = Vector3.Lerp(Body.transform.localPosition, initialPosition, Time.deltaTime * 5);
            Body.transform.localRotation = Quaternion.Lerp(Body.transform.localRotation, initialRotation, Time.deltaTime * 5);
            yield return new WaitForEndOfFrame();
        }
        Body.transform.localPosition = initialPosition;
        Body.transform.rotation = initialRotation;

        GetComponent<DefaultController>().enabled = true;
        GetComponent<SlidingController>().enabled = false;
        GetComponent<CameraController>().IsRotatingCharacter = true;
        endTime = Time.time;
    }
}
