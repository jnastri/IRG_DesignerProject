using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 5f;
    public GameObject impactEffect;
    Vector3 dir;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Use this for initialization
    void Start()
    {
        dir = target.position - transform.position;
        Invoke("DestroyObject", 4f);

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1.5f);
       // HUD_Manager.instance.curHealth -= 10;
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            HitTarget();
        }
        else
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 1.5f);
            Destroy(gameObject);
        }
    }
}
