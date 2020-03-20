using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalControllerB : MonoBehaviour {

    #region Delare Variables

    //declare the rangeFinder within this scope
    private rangeFinder rangefinder;

    //boolean to declare if the player is interacting with terminal
    public bool interacting;

    //boolean to declare if the player has seen the startup of the computer
    public bool startupComplete;

    //OnScreen GameObjects

    public Text starupText;
    public Text startupSubText;
    
    public Text headerText;
    public Text bodyText;

    public Text inputTextOne;
    public Text inputTextTwo;
    public Text inputTextThree;

    public GameObject terminalPanel;

    public Text interactionText;

    public string mailText;
    public string docText;
    public string computerInformation;

    #endregion


    // Use this for initialization
    void Start ()
    {
        rangefinder = GetComponent<rangeFinder>();

        interacting = false;
        startupComplete = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (interacting && startupComplete)
        {
            interactionControls();
        }
	}

    private void OnMouseEnter()
    {
        if (rangefinder.inRange && !interacting)
        {
            interactionText.text = "E] Interact";
        }
    }

    private void OnMouseExit()
    {
        interactionText.text = "";   
    }

    private void OnMouseOver()
    {
        if (!rangefinder.inRange)
        {
            interactionText.text = "";
        }   
    }

    //Called when the player selects to intetact with the Terminal
    void startUp()
    {
        //clear texts when the terminal starts up
        clearTexts();

        //Set the terminal as active so it is shown on the screen
        terminalPanel.SetActive(true);

        startupSequence();
    }

    void interactionControls()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {

        }

        if (Input.GetKey(KeyCode.Alpha2))
        {

        }

        if (Input.GetKey(KeyCode.Alpha3))
        {

        }

        if (Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.Escape))
        {
            shutDown();
        }
    }

    void shutDown()
    {
        terminalPanel.SetActive(false);
        //TODO play sound
    }

    void clearTexts()
    {
        //clear startup texts
        starupText.text = "";
        startupSubText.text = "";

        //clear general use texts
        headerText.text = "";
        bodyText.text = "";

        //clear option texts
        inputTextOne.text = "";
        inputTextTwo.text = "";
        inputTextThree.text = "";
    }

    void startupSequence()
    {

        //Coroutine
        starupText.text = "";
        //startupSubText.text = "";
        startupComplete = true;

    }
}
