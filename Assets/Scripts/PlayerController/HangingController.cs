using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingController : MonoBehaviour {

    public Animator Animator;

    Vector3 HandlePosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    internal void Trigger()
    {
        Animator.SetBool(ControllerSettings.IS_HANGING, true);
        HandlePosition = transform.position + Vector3.down * 3;
        GetComponent<Rigidbody>().isKinematic = true;
        enabled = true;
        GetComponent<CameraController>().DisableBodyRotation();
        GetComponent<DefaultController>().enabled = false;
        StartCoroutine(AdjustPosition());
    }

    IEnumerator AdjustPosition()
    {
        yield return new WaitForSeconds(1);
        while (Vector3.Distance(transform.position, HandlePosition) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, HandlePosition, 5f);
            yield return new WaitForEndOfFrame();
        }
        GetComponent<CameraController>().DisableBodyRotation();
        GetComponent<DefaultController>().enabled = false;
    }
}
