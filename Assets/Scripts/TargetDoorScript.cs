using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDoorScript : MonoBehaviour
{
    public enum TargetAmount {OneTarget, TwoTargets, ThreeTargets, FourTargets, FiveTargets}
    [Header("Animated Object")]
    [Tooltip("Object that will be animated when all of the targets are hit")]
    public GameObject animatedObj;
    [Tooltip("Name of the activation bool for the animated object.")]
    public string animatedObjBool;

    [Header("Targets")]
    public TargetAmount numberOfTargets;
    public bool[] targetChecks;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Completion()
    {
        animatedObj.GetComponent<Animator>().SetBool("isActive", true);
    }

    void CheckForCompletion()
    {
        if(targetChecks.Length <= 5 && targetChecks.Length >= 0)
        {
            for (int i = 0; i < targetChecks.Length; i++)
            {
                if (targetChecks[i] == true)
                {
                    Completion();
                }
            }
        }
        else
        {
            print("This is not a valid number of targets");
        }
    }

    public int TrackDoorTargets(int targetNum)
    {
        switch (targetNum)
        {
            case 1:
                targetChecks[0] = true;
                CheckForCompletion();
                break;
            case 2:
                targetChecks[1] = true;
                CheckForCompletion();
                break;
            case 3:
                targetChecks[2] = true;
                CheckForCompletion();
                break;
            case 4:
                targetChecks[3] = true;
                CheckForCompletion();
                break;
            case 5:
                targetChecks[4] = true;
                CheckForCompletion();
                break;
            default:
                break;
        }

        return targetNum;
    }
}
