using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingTrigger : MonoBehaviour
{

    public float EntrySpeed;

    DefaultController defaultController;
    SlidingController slidingController;
    // Use this for initialization
    void Start()
    {
        defaultController = GetComponent<DefaultController>();
        slidingController = GetComponent<SlidingController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - slidingController.endTime) > 0.1f && defaultController.PositionChangeClamped.magnitude > EntrySpeed && Input.GetAxis(ControllerSettings.SLIDE) > 0)
        {
            defaultController.enabled = false;
            slidingController.enabled = true;
        }
    }
}
