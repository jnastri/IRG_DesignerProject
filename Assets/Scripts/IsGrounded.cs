using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour {

    private PlayerController newPC;
	// Use this for initialization
	void Start () {
        newPC = GameObject.Find("Player").GetComponent<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        newPC.isGrounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        newPC.isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        newPC.isGrounded = false;
    }

}
