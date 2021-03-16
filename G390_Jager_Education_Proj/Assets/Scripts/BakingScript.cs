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
    public TextMeshPro eggresultText;
    public TextMeshPro flourresultText;
    public TextMeshPro sugarresultText;
    public TextMeshPro butterresultText;
    public TextMeshPro bakeresultText;
    public AudioSource player;
    public AudioClip pop;

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
            player.Play();

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
                        BakeCookies();
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

        //check egga mount
        if(eggs <= 40)
        {
            eggresultText.text = eggresultText.text + " You didn't add enough egg...your cookie tastes too sweet, no caramelization, dry on the outside and doughy on the inside.";
        }
        else if (eggs == 80 || eggs == 60)
        {
            eggresultText.text = eggresultText.text + " You added less egg than the full amount, so your cookie tastes extra sweet and maintained a thick profile. A little dry on the outside, but it's extra soft on the inside!";
        }
        else if (eggs == 100)
        {
            eggresultText.text = eggresultText.text + " You added the full amount of egg. Your cookie browns evenly, spreads a fair amount, but is still solid in the middle and isn't too sweet.";
        }
        else if (eggs == 120 || eggs == 140)
        {
            eggresultText.text = eggresultText.text + " You added extra egg. Your cookie spreads out a little much, making it a bit thinner and crispier. It's extra caramaelized on the outside and less sweet than your average cookie.";
        }
        else if (eggs >= 160)
        {
            eggresultText.text = eggresultText.text + " You added too much egg! Your cookie spreads very thin, isn't sweet, and browned to a crisp.";
        }

        //check flour amount
        if (flour <= 40)
        {
            flourresultText.text = flourresultText.text + " You didn't add enough flour...congrats you made cookie soup.";
        }
        else if (flour == 80 || flour == 60)
        {
            flourresultText.text = flourresultText.text + " You added less flour. Your cookie spreads out more for a thin and crispier profile, but the chocolate, sugar, and other flavors stand out boldly!";
        }
        else if (flour == 100)
        {
            flourresultText.text = flourresultText.text + " You added the full amount of flour. Your cookie lightly spreads in baking.";
        }
        else if (flour == 120 || flour == 140)
        {
            flourresultText.text = flourresultText.text + " You added extra flour. Your cookie holds its original shape and thickness without browning as much, but the main ingredient flavors are a bit muted.";
        }
        else if (flour >= 160)
        {
            flourresultText.text = flourresultText.text + " You added too much flour! Your cookie doesn't spread at all, and you taste the grains of wheat.";
        }

        //check sugar amount
        if (sugar <= 40)
        {
            sugarresultText.text = sugarresultText.text + " You didn't add enough sugar. Your cookie is completely dry and tastes mucky.";
        }
        else if (sugar == 80 || sugar == 60)
        {
            sugarresultText.text = sugarresultText.text + " You added less sugar. Your cookie doesn't spread as much and is less sweet, with the chocolate standing out more.";
        }
        else if (sugar == 100)
        {
            sugarresultText.text = sugarresultText.text + " You added the full amount of sugar. Your cookie spreads a moderate amount and is pleasantly sweet.";
        }
        else if (sugar == 120 || sugar == 140)
        {
            sugarresultText.text = sugarresultText.text + " You added extra sugar. Your cookie spreads more than usual and is very sweet, overpowering some of the other flavors.";
        }
        else if (sugar >= 160)
        {
            sugarresultText.text = sugarresultText.text + " You added too much sugar! Your cookie spread super flat and is basically a messed up caramel.";
        }

        //check butter amount
        if (butter <= 40)
        {
            butterresultText.text = butterresultText.text + " You didn't add enough butter. Your cookie doesn't brown and is dry and crackly.";
        }
        else if (butter == 80 || butter == 60)
        {
            butterresultText.text = butterresultText.text + " You added less butter. Your cookie is firm and is lacking savory flavor.";
        }
        else if (butter == 100)
        {
            butterresultText.text = butterresultText.text + " You added the full amount of butter. Your cookie browns evenly, is soft but firm, and has a nice layer of savoriness.";
        }
        else if (butter == 120 || butter == 140)
        {
            butterresultText.text = butterresultText.text + " You added extra butter. Your cookie is extra gooey and savory.";
        }
        else if (butter >= 160)
        {
            butterresultText.text = butterresultText.text + " You added too much butter! Your cookie is so gooey it falls apart as soon as you pick it up, and is quite greasy.";
        }

        bakeresultText.text = bakeresultText.text + " Press R to try again!";
    }
}
