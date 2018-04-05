using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpObjectScript : MonoBehaviour
{
    public enum ObjectType { ThreeOrMore, TwoPointLerp}
    public ObjectType typeOfMovingObject;
    public float speed;
    private float startSpeed;

    [Header("Only if ThreeOrMore is Chosen")]
    public Transform[] platformWaypoints;

    [Header("Only if TwoPointLerp is Chosen")]
    public Vector3 offSet;
    public float timeDelay;
    private float timeDelayStart;
    private bool isDirectionFlipped;

    private int currentWaypoint = 0;
	// Use this for initialization
	void Start ()
    {
        timeDelayStart = timeDelay;
        startSpeed = speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(typeOfMovingObject == ObjectType.ThreeOrMore)
        {
            MultiplePointLerp();
        }
        else if(typeOfMovingObject == ObjectType.TwoPointLerp)
        {
            NormalLerp();
        }
	}

    void NormalLerp()
    {
        timeDelay -= Time.deltaTime;
        print(timeDelay);
        if(timeDelay < 1)
        {
            speed -= Time.deltaTime;
            if (timeDelay < 0)
            {
                isDirectionFlipped = !isDirectionFlipped;
                timeDelay = timeDelayStart;
                speed = startSpeed;
            }
        }

        if (isDirectionFlipped)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - offSet, Time.deltaTime * speed * .67f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + offSet, Time.deltaTime * speed * .67f);
        }
    }

    void MultiplePointLerp()
    {
        if (transform.position != platformWaypoints[currentWaypoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, platformWaypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
        }
        else
        {
            currentWaypoint++;
        }

        if (currentWaypoint >= platformWaypoints.Length)
        {
            currentWaypoint = 0;
        }
    }
}
