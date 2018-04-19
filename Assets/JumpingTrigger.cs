using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingTrigger : BehaviorTrigger
{


    DefaultController defaultController;
    JumpingController jumpingController;
    // Use this for initialization
    void Start()
    {
        defaultController = GetComponent<DefaultController>();
        jumpingController = GetComponent<JumpingController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(ControllerSettings.JUMP) > 0)
        {
            DisableAllTriggersButMe();
            //defaultController.enabled = false;
            jumpingController.enabled = true;
        }
    }
}
