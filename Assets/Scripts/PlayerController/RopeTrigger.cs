using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTrigger : MonoBehaviour
{ 
     void Start()
    {

    }

    void Update()
    {

    }

    public void OnCollisionStay(Collision collision)
    {
        if (enabled)
        {
            var rope = collision.collider.GetComponent<Rope>();
            if (rope)
            {
                GetComponent<RopeController>().TriggerWalkEnter(rope);
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        var rope = collision.collider.GetComponent<Rope>();
        if (rope)
        {
            GetComponent<RopeController>().TriggerExit();
        }
    }
}
