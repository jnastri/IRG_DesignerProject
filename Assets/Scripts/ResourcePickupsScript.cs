using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickupsScript : MonoBehaviour
{
    public enum ResourceType { BatteryPickup, HealthPickup}
    public ResourceType typeOfResource;
    public int amountOfResource;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void GiveResource()
    {
        if(typeOfResource == ResourceType.BatteryPickup)
        {
            //Give amount of resource once HUD is complete to the Battery
        }
        else if(typeOfResource == ResourceType.HealthPickup)
        {
            //Give amount of resource once HUD is complete to the Health
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            GiveResource();
            Destroy(gameObject);
        }
    }
}
