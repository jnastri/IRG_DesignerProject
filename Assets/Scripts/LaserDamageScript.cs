using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamageScript : MonoBehaviour
{
    public float damage;
    public float damageInterval;
	// Use this for initialization
	void Start ()
    {
		
	}

    void ProduceDamage()
    {
        //Inflict damage to player by sending damage to the HUD.
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            InvokeRepeating("ProduceDamage", .3f, damageInterval);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            CancelInvoke("ProduceDamage");
        }
    }
}
