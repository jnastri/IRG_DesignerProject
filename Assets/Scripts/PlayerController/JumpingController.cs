using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingController : MonoBehaviour {

    public Animator Animator;

    new Rigidbody rigidbody;

    public float jumpForce = 100;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
        Animator.SetBool("IsJumping", true);
        rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        StartCoroutine(StopJumping());
    }

    private IEnumerator StopJumping()
    {
        yield return new WaitForEndOfFrame();
        
        yield return new WaitForSeconds(1);
        Animator.SetBool("IsJumping", false);
        GetComponent<JumpingTrigger>().EnableAllTriggers();
        enabled = false;
        GetComponent<DefaultController>().enabled = true;
    }
}
