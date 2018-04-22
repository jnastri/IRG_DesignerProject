using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{

    public GameObject Head;
    public GameObject Body;
    public CameraController CameraController;
    public Animator Animator;

    RopeTrigger ropeTrigger;
    ControllerSettings settings;
    // Use this for initialization
    void Start()
    {
        settings = GetComponent<ControllerSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis(ControllerSettings.VERTICAL_AXIS);
        transform.position += transform.forward * movement * Time.deltaTime * settings.Speed;
        if (movement > 0)
        {
            SetRotation();
            Body.transform.LookAt(transform.forward + Body.transform.position);
            SetAnimatorSpeed(movement);
        }
        else if (movement < 0)
        {
            SetRotation();
            Body.transform.LookAt(-transform.forward + Body.transform.position);
            SetAnimatorSpeed(-movement);
        }
        else
        {
            CameraController.EnableBodyRotation();
            SetAnimatorSpeed(0);
            if (Input.GetAxis(ControllerSettings.DROP_HANG) > 0)
            {
                TriggerExit();
                GetComponent<HangingController>().Trigger();
            }
        }
    }

    private void SetAnimatorSpeed(float speed)
    {
        Animator.SetFloat(ControllerSettings.SPEED, speed);
    }

    internal void TriggerWalkEnter(RopeTrigger ropeTrigger)
    {
        if (Animator.GetBool(ControllerSettings.IS_HANGING)) return;
        this.ropeTrigger = ropeTrigger;
        ToggleOtherControllers();
        SetPosition();
        SetRotation();
    }

    private void SetRotation()
    {
        CameraController.DisableBodyRotation();
        Vector3 projection = Vector3.Project(transform.forward, ropeTrigger.transform.position - transform.position);
        projection += transform.position;
        projection.y = transform.position.y;
        transform.LookAt(projection);
        Body.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    private void SetPosition()
    {
        Vector3 entryPosition = ropeTrigger.GetComponent<Collider>().ClosestPoint(transform.position);
        entryPosition.y = transform.position.y;
        transform.position = entryPosition;
    }

    private void ToggleOtherControllers()
    {
        enabled = true;
        GetComponent<DefaultController>().enabled = false;
        GetComponent<SlidingTrigger>().enabled = false;
    }

    internal void TriggerExit()
    {
        UntoggleControllers();
    }

    private void UntoggleControllers()
    {
        GetComponent<SlidingTrigger>().enabled = true;
        enabled = false;
        GetComponent<DefaultController>().enabled = true;
        CameraController.EnableBodyRotation();
    }
}
