using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTrigger : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        var ropeController = collision.collider.GetComponent<RopeController>();
        if (ropeController)
        {
            ropeController.TriggerWalkEnter(this);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        var ropeController = collision.collider.GetComponent<RopeController>();
        if (ropeController)
        {
            ropeController.TriggerWalkExit(this);
        }
    }
}
