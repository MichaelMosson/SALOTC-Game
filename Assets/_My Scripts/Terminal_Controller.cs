using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal_Controller : MonoBehaviour {

    #region declarations 

    //declare the rangeFinder within this scope
    private rangeFinder rangefinder;

    //reference the on screen interaction text
    public Text interactText;

    //reference the text that shows the information in the terminal
    public Text terminalText;

    //boolean to show if the player is interating with the terminal or not
    public bool interacting;

    //gameobject to reference the terminals UI objects
    public GameObject terminal;

    //gameobject to reference the input box in the terminal UI
    public GameObject inputBox;
    public InputField terminalInputBox;

    //text reference for input box
    public Text inputText;

    //string to handle player input 
    string inputtedText;

    public bool startUpComplete;

    #endregion

    // Use this for initialization
    void Start () {
        rangefinder = GetComponent<rangeFinder>();

        //set interacting to false as the player does not start the game interacting with the gameobject
        interacting = false;

        //mark that startUp has not taken place
        startUpComplete = false;
        
        //clears the text when the player starts the game
        clearText();

        //clears thhe inputted text
        inputtedText = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        //loops when the player is using the terminal after startup
        if (interacting && startUpComplete)
        {
            terminalInteraction();
        }
	}

    #region physicalInteraction
    //This function is called when the player's mouse enters the box collider of the GameObject
    private void OnMouseEnter()
    {
        if (rangefinder.inRange && !interacting)
        {
            //show the text
            interactText.text = "[E] Interact";
        }

    }

    private void OnMouseOver()
    {
        if (!rangefinder.inRange)
        {
            //Hide Text
            clearText();
        }

        //activate the terminal
        if (Input.GetKey(KeyCode.E) && rangefinder.inRange && !interacting)
        {
            initiateTerminal();
            Debug.Log("Play attempts to interact with Terminal");
        }
    }

    private void OnMouseExit()
    {
        if (rangefinder.inRange)
        {
            clearText();
        }
    }

    void initiateTerminal()
    {
        //clears the onscreen text to ready the player for the terminal
        clearText();

        //delcares that the player is interacting with the terminal
        interacting = true;

        //TODO freeze the player's playercharacter

        //set the TerminalScreen gameobject active
        terminal.gameObject.SetActive(true);

        runStartUp();

        Time.timeScale = 0;
        Debug.Log("Game has been paused");

    }

    void logoffTerminal()
    {
        //set the TerminalScreen gameobject unactive
        terminal.gameObject.SetActive(false);

        //set the inputbox gamobject unactive
        inputBox.gameObject.SetActive(false);

        //set the player to not be interacting 
        interacting = false;

        //reset the terminal?
        inputtedText = "";
        inputText.text = "";

        Time.timeScale = 1;
        Debug.Log("Game has been restarted");
    }

    //clears the interaction text
    void clearText()
    {
        interactText.text = "";
        Debug.Log("interactText has been cleared");
    }

    #endregion

    #region TerminalInteraction

    void runStartUp()
    {
        //startup will be implemented later

        startUpComplete = true;

        //inputBox.gameObject.SetActive(true);
        //set input box as the default input field
        //terminalInputBox.Select();

        selectIputBox();

        Debug.Log("Startup has run successfully");

        defaultTerminalText();

        

    }

    public void selectIputBox()
    {
        inputBox.gameObject.SetActive(true);
        //set input box as the default input field
        terminalInputBox.Select();
    }

    void terminalInteraction()
    {
        if (Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Player logs off of the Terminal");
            logoffTerminal();
        }

        //if(Input.GetKeyDown(KeyCode.Return))
        if(Input.GetKey(KeyCode.Return))
        {
            handleTerminalInput();
        }
        

    }

    void defaultTerminalText()
    {
        terminalText.text = "Please enter a command and press enter. Type 'help' to view available commands.";
    }

    //function to handle the input to the terminal
    void handleTerminalInput()
    {
        inputtedText = inputText.text;

        Debug.Log(inputtedText+" entered into the terminal");

        //clears the input text
        inputText.text = "";

        if (inputtedText == "help")
        {
            terminalText.text = "docs - View Documents \n mail - view mail \n logoff - turn off computer";
        }

        else if (inputtedText == "mail")
        {
            terminalText.text = "This is place holder mail text";
        }

        else if (inputtedText == "docs")
        {
            terminalText.text = "This document is to show how Rory Stirling was the real murderer";
        }

        //note this is currently broken $$
        else if (inputtedText == "details")
        {
            terminalText.text = "This terminal belongs to MegaCorp Systems \n Main User: \n User Job Title:";
        }
        else if (inputtedText == "")
        {
            terminalText.text = "Enter a command.";
        }
        else { terminalText.text = "ERROR 404 - COMMAND NOT RECOGNISED"; }

        selectIputBox();

        
    }

    #endregion


}
