﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSettings : MonoBehaviour {
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
    public const string SPEED = "Speed";
    public const string IS_JUMPING = "IsJumping";
    public static string IS_HANGING = "IsHanging";
    public const string SLIDE = "Slide";
    public const string DROP_HANG = SLIDE;
    public const string JUMP = "Jump";
    public const string IS_GROUNDED = "IsGrounded";
    public GameObject Camera;
    public float Speed = 12;
    public Animator Animator;

    float distanceToGround;
    bool isColliding = false;


    public bool IsGrounded;

    public void updateIsGrounded()
    {
        IsGrounded = isColliding || Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    // Use this for initialization
    void Start () {
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        Camera = FindObjectOfType<DefaultCamera>().gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        updateIsGrounded();
        Animator.SetBool(IS_GROUNDED, IsGrounded);
        isColliding = false;
    }

    void OnCollisionStay()
    {
        isColliding = true;
    }
}
