using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BakingScript : MonoBehaviour
{
    //private variables
    private Rigidbody rB;
    private bool canBake;
    int eggs = 0;
    int flour = 0;
    int sugar = 0;
    int butter = 0;

    //public variables
    public TextMeshPro amountTextEggs;
    public TextMeshPro amountTextFlour;
    public TextMeshPro amountTextSugar;
    public TextMeshPro amountTextButter;

    // Start is called before the first frame update
    void Start()
    {
        //start stuff as child
        rB = GetComponent<Rigidbody>();
        canBake = true;
        SetText();
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
                if(canBake == true)
                {
                    if (interactedObject.tag == "Eggs")
                    {
                        Debug.Log("You added eggs!");
                        eggs += 20;
                        SetText();
                    }
                    else if (interactedObject.tag == "Flour")
                    {
                        Debug.Log("You added Flour!");
                        flour += 20;
                        SetText();
                    }
                    else if (interactedObject.tag == "Sugar")
                    {
                        Debug.Log("You added Sugar!");
                        sugar += 20;
                        SetText();
                    }
                    else if (interactedObject.tag == "Butter")
                    {
                        Debug.Log("You added Butter!");
                        butter += 20;
                        SetText();
                    }
                    else if (interactedObject.tag == "Bake")
                    {
                        Debug.Log("You bake the cookies!");
                        
                    }
                    else
                    {
                        Debug.Log("No object!");
                    }
                }
            }
        }

        //reset button
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetText()
    {
        //countText.text = "Coins: " + count.ToString();
        amountTextEggs.text = eggs.ToString() + "%";
        amountTextFlour.text = flour.ToString() + "%";
        amountTextSugar.text = sugar.ToString() + "%";
        amountTextButter.text = butter.ToString() + "%";
    }

    void BakeCookies()
    {
        canBake = false;

        if(eggs <= 60)
        {

        }
        else if (eggs == 80)
        {

        }
        else if (eggs == 100)
        {

        }
        else if (eggs == 120)
        {

        }
        else if (eggs >= 140)
        {

        }
    }
}
