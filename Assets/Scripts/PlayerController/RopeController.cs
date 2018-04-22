using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour {

    public GameObject Head;
    public GameObject Body;

    RopeTrigger ropeTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var position = ropeTrigger.transform.position;
        position.y = transform.position.y;
        Vector3 direction = position - transform.position;
        Debug.DrawRay(transform.position, direction);
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        Body.transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.005f * Time.time);

    }

    internal void TriggerWalkEnter(RopeTrigger ropeTrigger)
    {
        this.ropeTrigger = ropeTrigger;
        enabled = true;
        GetComponent<SlidingTrigger>().enabled = false;
        GetComponent<CameraController>().IsRotatingCharacter = false;
    }


    internal void TriggerWalkExit(RopeTrigger ropeTrigger)
    {
        GetComponent<SlidingTrigger>().enabled = true;
        enabled = false;
        GetComponent<CameraController>().IsRotatingCharacter = true;
    }
}
