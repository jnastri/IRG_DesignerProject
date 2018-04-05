using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTypeScript : MonoBehaviour
{
    public enum InteractType { Console, Door}
    public InteractType typeOfInteractable;

    public void Activate()
    {
        if(typeOfInteractable == InteractType.Console)
        {
            //Interact with Console
        }
        else if (typeOfInteractable == InteractType.Door)
        {
            //Interact with Door
        }
    }
}
