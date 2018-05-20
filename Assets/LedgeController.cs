using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeController : MonoBehaviour
{

    public Animator Animator;

    Vector3 HandlePosition;

    bool canDrop = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canDrop && Input.GetAxis(ControllerSettings.DROP_HANG) > 0)
        {
            enabled = false;
        }
    }

    void OnEnable()
    {
        canDrop = false;
        GetComponent<LedgeTrigger>().enabled = false;
        GetComponent<RopeController>().enabled = false;
        GetComponent<RopeTrigger>().enabled = false;
        GetComponent<SlidingTrigger>().enabled = false;
        Animator.SetBool(ControllerSettings.IS_HANGING, true);
        HandlePosition = transform.position + Vector3.down * 3;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CameraController>().DisableBodyRotation();
        GetComponent<DefaultController>().enabled = false;
        StartCoroutine(AdjustPosition());
    }

    IEnumerator AdjustPosition()
    {
        yield return new WaitForSeconds(1);
        while (Vector3.Distance(transform.position, HandlePosition) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, HandlePosition, 5f);
            yield return new WaitForEndOfFrame();
        }
        GetComponent<CameraController>().DisableBodyRotation();
        GetComponent<DefaultController>().enabled = false;
        canDrop = true;
    }

    void OnDisable()
    {
        GetComponent<RopeTrigger>().enabled = true;
        GetComponent<SlidingTrigger>().enabled = true;
        Animator.SetBool(ControllerSettings.IS_HANGING, false);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<CameraController>().EnableBodyRotation();
        GetComponent<DefaultController>().enabled = true;
        GetComponent<LedgeTrigger>().enabled = true;
    }


}
