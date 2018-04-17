using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultController : MonoBehaviour
{

    public float Speed = 8;
    public float MouseSensitivity = 150;
    public float MaxLookUp = 0.6f;
    public float MaxLookDown = 0.65f;
    public GameObject Head;
    public GameObject Body;
    public Animator Animator;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Animator = Body.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }

    void FixedUpdate()
    {

    }

    private void UpdateRotation()
    {
        float h = MouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        float v = -MouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

        transform.Rotate(0, h, 0);
        Head.transform.Rotate(v, 0, 0);

        RotationClamping();
    }

    private void RotationClamping()
    {
        if (Head.transform.localRotation.x > MaxLookDown)
        {
            Head.transform.localRotation = new Quaternion(MaxLookDown, 0, 0, Head.transform.localRotation.w);
        }
        else if (Head.transform.localRotation.x < MaxLookUp)
        {
            Head.transform.localRotation = new Quaternion(MaxLookUp, 0, 0, Head.transform.localRotation.w);
        }
    }

    private void UpdateMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector3 positionChange = transform.right * horizontal * Time.deltaTime * Speed;
        positionChange += transform.forward * vertical * Time.deltaTime * Speed;

        Debug.Log(transform.right + transform.position);
        Vector3 lookAt = Vector3.zero;
        if (horizontal > 0)
        {
            lookAt += transform.right;
        }
        else if (horizontal < 0)
        {
            lookAt -= transform.right;
        } 

        if(vertical > 0)
        {
            lookAt += transform.forward;
        } else if(vertical < 0)
        {
            lookAt -= transform.forward;
        }
        lookAt += transform.position;
        lookAt.y = Body.transform.position.y;
        Debug.Log(lookAt);
        Body.transform.LookAt(lookAt);

        transform.position += positionChange;
        Animator.SetFloat("Speed", positionChange.magnitude);
    }
}
