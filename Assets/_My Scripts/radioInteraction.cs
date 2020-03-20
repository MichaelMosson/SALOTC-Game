using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radioInteraction : MonoBehaviour {

    private rangeFinder rangefinder;
    public Text interactionText;
    public string interactionTextContents;

    //bool to show if the player is currently using the terminal
    public bool radioActivated;

	// Use this for initialization
	void Start ()
    {
        rangefinder = GetComponent<rangeFinder>();
        radioActivated = false;

        if (interactionTextContents == "")
        {
            interactionTextContents = "default text";
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnMouseOver()
    {
        
    }

    private void OnMouseExit()
    {
        
    }

    public void activation()
    {
        
    }

    public void displayText()
    {

    }

    public void hideText()
    {

    }

    
}
