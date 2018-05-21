using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeTrigger : MonoBehaviour
{

    public GameObject Body;

    public LedgeDetector LedgeDetector;
    public ControllerSettings Settings;
    LedgeController ledgeController;

    // Use this for initialization
    void Start()
    {
        ledgeController = GetComponent<LedgeController>();

    }
    HangingResult orientation;

    // Update is called once per frame
    void Update()
    {
        if (Settings.IsGrounded && Input.GetAxis(ControllerSettings.DROP_HANG) > 0 && (orientation = LedgeDetector.GetHangingOrientation()) != null)
        {
            Debug.Log(Settings.IsGrounded);
            ledgeController.Orientation = orientation;
            ledgeController.enabled = true;
        }
    }


}
