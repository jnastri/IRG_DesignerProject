using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTrigger : MonoBehaviour
{

    RopeController ropeController;

    void Start()
    {
        ropeController = GetComponent<RopeController>();
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
                ropeController.rope = rope;
                ropeController.enabled = true;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        var rope = collision.collider.GetComponent<Rope>();
        if (rope)
        {
            ropeController.enabled = false;
        }
    }
}
