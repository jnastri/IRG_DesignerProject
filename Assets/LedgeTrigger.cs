using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeTrigger : MonoBehaviour {

    public GameObject Body;

    public LedgeDetector LedgeDetector;
    LedgeController ledgeController;

	// Use this for initialization
	void Start () {
        ledgeController = GetComponent<LedgeController>();

    }
    HanginResult orientation;
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis(ControllerSettings.DROP_HANG) > 0 && (orientation = LedgeDetector.GetHangingOrientation()) != null)
        {
            GetComponent<CameraController>().DisableBodyRotation();
            var rotation = Quaternion.Euler(orientation.Rotation + new Vector3(13.72f, -130, -14.769f));
            Body.transform.rotation = rotation;
            Debug.Log(orientation + " vs " + Body.transform.rotation.eulerAngles);
            transform.position = orientation.Position + Vector3.up * 1.2f - (Body.transform.forward* 0.4220133f * 1.8f);
            ledgeController.enabled = true;
        }
    }


}
