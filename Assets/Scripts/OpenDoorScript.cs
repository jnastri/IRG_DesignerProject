using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public GameObject openingDoor;
    public Light[] doorLights;

    public bool isOpen;
	// Use this for initialization
	void Start ()
    {
        ChangeLights();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void ChangeLights()
    {
        if (isOpen)
        {
            for(int i = 0; i < doorLights.Length; i++)
            {
                doorLights[i].color = Color.green;
            }
        }
        else
        {
            for (int i = 0; i < doorLights.Length; i++)
            {
                doorLights[i].color = Color.red;
            }
        }
    }

    void OpenTheDoor()
    {
        openingDoor.GetComponent<Animator>().SetBool("isActive", true);
    }

    void CloseDoor()
    {
        openingDoor.GetComponent<Animator>().SetBool("isActive", false);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            if (isOpen)
            {
                OpenTheDoor();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            CloseDoor();
        }
    }
}
