using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampRotation : MonoBehaviour
{
    public Transform Body;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.localRotation.eulerAngles.y > 90)
        //{
        //    var a = transform.localRotation.eulerAngles;
        //    a.y = 0;
        //    transform.localRotation = Quaternion.Euler(a);
        //}
        //else if (transform.localRotation.eulerAngles.y < -90)
        //{
        //    var a = transform.localRotation.eulerAngles;
        //    a.y = 0;
        //    transform.localRotation = Quaternion.Euler(a);
        //}
        
    }

    void OnCollisionStay(Collision collision)
    {
        
        
        var shoveDistance = transform.position + transform.position - Body.transform.position;
        shoveDistance.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, transform.position, Time.deltaTime * 10);
    }
}
