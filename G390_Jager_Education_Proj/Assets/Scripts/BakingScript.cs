using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingScript : MonoBehaviour
{
    //private variables
    private Rigidbody rB;
    private bool canBake;
    int eggs;
    int flour;
    int sugar;
    int butter;

    //public variables
    public Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        //start stuff as child
        rB = GetComponent<Rigidbody>();
        canBake = true;

    }

    //called last every frame
    private void FixedUpdate()
    {
        //detect mouse input
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse clicked!");

            //send out a raycast to detect collisions
            Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit interactionInfo;
            if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
            {
                //check the object interacted with, if the previous object has been found then this item can now be found
                GameObject interactedObject = interactionInfo.collider.gameObject;
                if (interactedObject.tag == "Eggs")
                {
                    Debug.Log("You added eggs!");

                }
                else if (canBake == true && interactedObject.tag == "Flour")
                {
                    Debug.Log("You added Flour!");
                }
                else if (canBake == true && interactedObject.tag == "Sugar")
                {
                    Debug.Log("You added Sugar!");
                }
                else if (canBake == true && interactedObject.tag == "Butter")
                {
                    Debug.Log("You added Butter!");
                }
                else if (canBake == true && interactedObject.tag == "Leavener")
                {
                    Debug.Log("You added leavening agent!");
                }
                else
                {
                    Debug.Log("No object!");
                }
            }
        }
    }
}
