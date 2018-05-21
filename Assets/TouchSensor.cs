using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensor : MonoBehaviour {

    public bool IsTriggered;


	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = Color.green;
	}
	

	public void Test() {
        Debug.DrawRay(transform.position, -Vector3.up);
        if(Physics.Raycast(transform.position, -Vector3.up, 1 + 0.1f))
        {
            GetComponent<Renderer>().material.color = Color.red - Color.black * 0.9f;
            IsTriggered = true;
        } else
        {
            GetComponent<Renderer>().material.color = Color.green - Color.black * 0.9f;
            IsTriggered = false;
        }
        
    }

    internal void Mark()
    {
        GetComponent<Renderer>().material.color = Color.blue - Color.black * 0.9f;
    }
}
