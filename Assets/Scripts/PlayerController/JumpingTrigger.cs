using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingTrigger : BehaviorTrigger
{


    DefaultController defaultController;
    JumpingController jumpingController;
    float distanceToGround;
    // Use this for initialization
    void Start()
    {
        defaultController = GetComponent<DefaultController>();
        jumpingController = GetComponent<JumpingController>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(ControllerSettings.JUMP) > 0 && IsGrounded())
        {
            DisableAllTriggersButMe();
            jumpingController.enabled = true;
        }
    }
}
