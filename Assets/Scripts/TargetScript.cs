using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public enum targetNum {Target1, Target2, Target3, Target4, Target5 }
    public targetNum num;
    public GameObject connectedTargetDoor;

    private TargetDoorScript newTargetDoorScript;
	// Use this for initialization
	void Start ()
    {
        newTargetDoorScript = connectedTargetDoor.GetComponent<TargetDoorScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void TargetActivated()
    {
        if(num == targetNum.Target1)
        {
            newTargetDoorScript.TrackDoorTargets(1);
        }
        else if (num == targetNum.Target2)
        {
            newTargetDoorScript.TrackDoorTargets(2);
        }
        else if (num == targetNum.Target3)
        {
            newTargetDoorScript.TrackDoorTargets(3);
        }
        else if (num == targetNum.Target4)
        {
            newTargetDoorScript.TrackDoorTargets(4);
        }
        else if (num == targetNum.Target5)
        {
            newTargetDoorScript.TrackDoorTargets(5);
        }
        else
        {
            print("Not a valid Target!");
        }
    }
}
