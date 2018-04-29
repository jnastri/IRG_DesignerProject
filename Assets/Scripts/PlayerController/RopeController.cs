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

    Rope rope;
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
        if (movement != 0)
        {
            var directionRelativeOfCamera = Vector3.Project(settings.Camera.transform.forward, rope.Points[0].position - rope.Points[1].position);
            transform.position += directionRelativeOfCamera * movement * Time.deltaTime * settings.Speed;
            Body.transform.LookAt(directionRelativeOfCamera + Body.transform.position);
            AlignWithRope();
            SetAnimatorSpeed(movement);
        }
        else
        {
            SetAnimatorSpeed(0);
            if (Input.GetAxis(ControllerSettings.DROP_HANG) > 0)
            {
                TriggerExit();
                GetComponent<HangingController>().Trigger();
            }
        }
    }

    private void AlignWithRope()
    {
        var pointA = rope.Points[0].position;
        var pointB = rope.Points[1].position;
        var closestPoint = GetClosestPointOnLine(pointA, pointB, transform.position);
        closestPoint.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, closestPoint, 0.1f);
    }

    Vector3 GetClosestPointOnLine(Vector3 vA, Vector3 vB, Vector3 vPoint)
    {
        var vVector1 = vPoint - vA;
        var vVector2 = (vB - vA).normalized;

        var d = Vector3.Distance(vA, vB);
        var t = Vector3.Dot(vVector2, vVector1);

        if (t <= 0)
            return vA;

        if (t >= d)
            return vB;

        var vVector3 = vVector2 * t;

        var vClosestPoint = vA + vVector3;

        return vClosestPoint;
    }

    private void SetAnimatorSpeed(float speed)
    {
        Animator.SetFloat(ControllerSettings.SPEED, speed);
    }

    internal void TriggerWalkEnter(Rope rope)
    {
        if (Animator.GetBool(ControllerSettings.IS_HANGING)) return;
        this.rope = rope;
        GetComponent<RopeTrigger>().enabled = false;
        ToggleOtherControllers();
        SetPosition();
        SetRotation();
    }

    private void SetRotation()
    {
        CameraController.DisableBodyRotation();
        CameraController.EnableWiderAngle();
        Vector3 projection = Vector3.Project(transform.forward, rope.transform.position - transform.position);
        projection += transform.position;
        projection.y = transform.position.y;
        transform.LookAt(projection);
        Body.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    private void SetPosition()
    {
        Vector3 entryPosition = rope.GetComponent<Collider>().ClosestPoint(transform.position);
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
        GetComponent<RopeTrigger>().enabled = true;
        GetComponent<DefaultController>().enabled = true;
        CameraController.EnableBodyRotation();
        CameraController.DisableWiderAngle();
    }
}
