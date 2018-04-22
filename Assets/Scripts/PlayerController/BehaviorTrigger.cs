using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    protected void DisableAllTriggersButMe()
    {
        var triggers = GetComponents<BehaviorTrigger>();
        foreach (var trigger in triggers)
        {
            trigger.enabled = false;
        }
        enabled = true;
    }

    public void EnableAllTriggers()
    {
        var triggers = GetComponents<BehaviorTrigger>();
        foreach (var trigger in triggers)
        {
            trigger.enabled = true;
        }
    }

}
