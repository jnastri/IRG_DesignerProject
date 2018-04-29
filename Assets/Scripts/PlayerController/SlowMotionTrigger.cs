using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E)) Time.timeScale = 0.01f;
	}
}
