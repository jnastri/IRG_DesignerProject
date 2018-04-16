using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCamera : MonoBehaviour
{

    public GameObject Target;

    public float Speed = 8;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, Speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.transform.rotation, Speed* Time.deltaTime);
    }
}
