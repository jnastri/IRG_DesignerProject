using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingTrigger : BehaviorTrigger
{


    DefaultController defaultController;
    JumpingController jumpingController;
    ControllerSettings settings;
    // Use this for initialization
    void Start()
    {
        defaultController = GetComponent<DefaultController>();
        jumpingController = GetComponent<JumpingController>();
        settings = GetComponent<ControllerSettings>();

    }

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(ControllerSettings.JUMP) > 0 && settings.IsGrounded())
        {
            DisableAllTriggersButMe();
            jumpingController.enabled = true;
        }
    }
}
