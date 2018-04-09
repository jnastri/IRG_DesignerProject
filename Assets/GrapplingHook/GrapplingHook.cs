using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

    //23:00 up to

    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public bool hooked;
    public static bool fired;
    public GameObject hookedObj;

    public float maxDistance;
    private float currentDistance;

    private void Update()
    {
        //firing the hook
        if (Input.GetMouseButtonDown(0) && fired == false)
        {
            fired = true;
        }

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
            {
                ReturnHook();
            }
        }

        if (hooked == true) {
            hook.transform.parent = hookedObj.transform;
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, playerTravelSpeed * Time.deltaTime);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            this.GetComponent<Rigidbody>().useGravity = false;

            if(distanceToHook < 1)
            {
                ReturnHook();
            }
            else
            {
                hook.transform.parent = hookHolder.transform;
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }


  
    }

    void ReturnHook()
    {
        
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hooked = false;
    }

}
