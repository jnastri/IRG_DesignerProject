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
    internal const string JUMP = "Jump";

    public float Speed = 12;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
