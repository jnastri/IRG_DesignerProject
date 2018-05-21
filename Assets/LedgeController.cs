using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeController : MonoBehaviour
{

    public Animator Animator;
    public GameObject Body;
    public HangingResult Orientation;

    Vector3 HandlePosition;
    bool canDrop = false;
    float cooldown;
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
        if (Time.time - cooldown < 1)
        {
            enabled = false;
            return;
        }
        GetComponent<CameraController>().DisableBodyRotation();
        Debug.Log(Orientation.Rotation);
        var rotation = Quaternion.Euler(Orientation.Rotation + new Vector3(0, -137, 0));
        Body.transform.rotation = rotation;

        canDrop = false;
        GetComponent<LedgeTrigger>().enabled = false;
        GetComponent<RopeController>().enabled = false;
        GetComponent<RopeTrigger>().enabled = false;
        GetComponent<SlidingTrigger>().enabled = false;
        Animator.SetBool(ControllerSettings.IS_HANGING, true);
        HandlePosition = Vector3.down * 1.8f + Orientation.Position + (Body.transform.forward * 0.3f);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CameraController>().DisableBodyRotation();
        GetComponent<DefaultController>().enabled = false;
        StartCoroutine(AdjustPosition());
    }

    IEnumerator AdjustPosition()
    {
        yield return new WaitForSeconds(.5f);
        while (Vector3.Distance(transform.position, HandlePosition) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, HandlePosition, Time.deltaTime * 3f);
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
        cooldown = Time.time;
    }


}
