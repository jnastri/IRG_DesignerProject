using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingScript : MonoBehaviour
{
    private List <GameObject> interactables;
    private float range = 15f;
    private SphereCollider playerTrigger;
    private InteractableTypeScript newType;
	// Use this for initialization
	void Start ()
    {
        playerTrigger = GetComponent<SphereCollider>();
        playerTrigger.radius = range;
	}

    void UpdateClosestIneractable()
    {
        float shortestDist = Mathf.Infinity;
        GameObject nearestInteractable = null;
        foreach(GameObject interactObj in interactables)
        {
            float distToInteractable = Vector3.Distance(transform.position, interactObj.transform.position);
            if(distToInteractable < shortestDist)
            {
                shortestDist = distToInteractable;
                nearestInteractable = interactObj;
            }
        }

        if(nearestInteractable != null && shortestDist <= range)
        {
            newType = nearestInteractable.GetComponent<InteractableTypeScript>();
            Interact();
        }
    }

    void Interact()
    {
        newType.Activate();
    }

    #region Triggers
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Interactable")
        {
            interactables.Add(col.gameObject);
            UpdateClosestIneractable();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Interactable")
        {
            UpdateClosestIneractable();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Interactable")
        {
            interactables.Remove(col.gameObject);
        }
    }
    #endregion
}
