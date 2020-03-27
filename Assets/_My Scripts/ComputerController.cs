using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour {

    private rangeFinder RangeFinder;

    #region Canvas Elements

    public Text interactionText;

    public Text headerText;
    public Text bodyText;
    public Text footerText;

    public GameObject terminalPanel;

    #endregion

    bool interacting;

    public string ownerName;

    int computerStage;

    public string[] mailTitle = new string[3] { "", "", ""};
    public string[] mailContents = new string[3] { "", "", "" };

    public string[] docsTitle = new string[3] { "", "", "" };
    public string[] docsContents = new string[3] { "", "", "" };

    //array for mail

    //array for docs

    // Use this for initialization
    void Start ()
    {
        computerStage = 0;
        RangeFinder = GetComponent<rangeFinder>();
        interacting = false;
	}

    // Update is called once per frame
    void Update ()
    {
        if (interacting)
        {
            ActiveControls();
        }
	}

    #region physical interaction

    private void OnMouseOver()
    {
        if (RangeFinder.inRange && !interacting)
        {
            interactionText.text = "[E] Activate";

            if (Input.GetKey(KeyCode.E))
            {
                StartUp();
            }
        }

        if (!RangeFinder.inRange || interacting)
        {
            interactionText.text = "";
        }
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        interactionText.text = "";
    }

    #endregion

    void ClearTexts()
    {
        interactionText.text = "";
        headerText.text = "";
        bodyText.text = "";
        footerText.text = "";
    }

    IEnumerator StartUpSequence()
    {
        headerText.text = "Initilizing Please Wait";
        yield return new WaitForSeconds(0.3f);
        headerText.text = "Initilizing Please Wait.";
        yield return new WaitForSeconds(0.3f);
        headerText.text = "Initilizing Please Wait..";
        yield return new WaitForSeconds(0.3f);
        headerText.text = "Initilizing Please Wait...";
        yield return new WaitForSeconds(0.3f);
        headerText.text = "Initilization Complete";
        yield return new WaitForSeconds(0.5f);
        headerText.text = "M";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "ME";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEG";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGA";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGAC";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACO";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACOR";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACORP";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACORP O";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACORP OS";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACORP OS V";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACORP OS V2";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACORP OS V2.";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACORP OS V2.6";
        yield return new WaitForSeconds(0.07f);
        headerText.text = "MEGACORP OS V2.63";

        yield return new WaitForSeconds(0.5f);
        bodyText.text = "Mounting C Drive";
        yield return new WaitForSeconds(0.5f);
        bodyText.text = "Mounting C Drive.";
        yield return new WaitForSeconds(0.7f);
        bodyText.text = "Mounting C Drive..";
        yield return new WaitForSeconds(0.6f);
        bodyText.text = "Mounting C Drive...";
        yield return new WaitForSeconds(1f);
        bodyText.text = "C Drive Mounted Successfully \nTesting BIOS";
        yield return new WaitForSeconds(0.6f);
        bodyText.text = "C Drive Mounted Successfully \nTesting BIOS.";
        yield return new WaitForSeconds(0.5f);
        bodyText.text = "C Drive Mounted Successfully \nTesting BIOS..";
        yield return new WaitForSeconds(0.5f);
        bodyText.text = "C Drive Mounted Successfully \nBIOS Test Successful";

        yield return new WaitForSeconds(0.8f);
        bodyText.text = "Hello " +ownerName+ ", please wait whilst your settings are loaded.";

        yield return new WaitForSeconds(1.3f);
        ShowMainMenuText();

    }

    void StartUp()
    {
        interacting = true;
        //Time.timeScale = 0;
        terminalPanel.SetActive(true);
        ClearTexts();
        StartCoroutine("StartUpSequence");
        

        

    }

    void ShutDown()
    {
        terminalPanel.SetActive(false);
        Time.timeScale = 1;
        StopCoroutine("StartUpSequence");
        interacting = false;
        ClearTexts();
    }

    

    void ActiveControls()
    {
        if (Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.Escape))
        {
            ShutDown();
        }

        //Main Menu Controls
        if (computerStage == 1)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                ShowMailText();
            }
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                ShowDocsText();
            }
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                ShowInfoText();
            }
        }

        // Mail Page Controls
        if (computerStage == 2)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                bodyText.text = mailContents[0];
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                bodyText.text = mailContents[1];
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                bodyText.text = mailContents[2];
            }

            if (Input.GetKey(KeyCode.Backspace))
            {
                ShowMainMenuText();
            }
        }

        // Docs Page Controls
        if (computerStage == 3)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                bodyText.text = docsContents[0];
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                bodyText.text = docsContents[1];
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                bodyText.text = docsContents[2];
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                ShowMainMenuText();
            }
        }

        // Information Page Controls
        if (computerStage == 4)
        {
            /*if (Input.GetKey(KeyCode.Alpha1))
            {

            }
            if (Input.GetKey(KeyCode.Alpha2))
            {

            }
            if (Input.GetKey(KeyCode.Alpha3))
            {

            }*/
            if (Input.GetKey(KeyCode.Backspace))
            {
                ShowMainMenuText();
            }
        }
    }

    #region Terminal Functions

    

    void ShowMainMenuText()
    {

        StopCoroutine("StartUpSequence");
        Time.timeScale = 0;

        computerStage = 1;
        headerText.text = "Mega Corp OS V2.63 | INTERNAL USE ONLY";
        bodyText.text = "Hello " + ownerName + " please select a function from the list below..." +
            "\n 1 - View Mail" +
            "\n 2 - View Documents" +
            "\n 3 - View Computer Information";
        footerText.text = "Press [TAB] to power down terminal";
    }

    void ShowMailText()
    {
        computerStage = 2;
        headerText.text = "Mega Corp OS V2.63 | INTERNAL USE ONLY";
        bodyText.text = "Hello " + ownerName + " please select an electronic mail from the list below..." +
            "\n 1 - " + mailTitle[0] +
            "\n 2 - " + mailTitle[1] +
            "\n 3 - " + mailTitle[2];
        footerText.text = "| Press [TAB] to power down terminal | \n| Press [BACKSPACE] to return to the Main Menu |";
    }

    void ShowDocsText()
    {
        computerStage = 3;
        headerText.text = "Mega Corp OS V2.63 | INTERNAL USE ONLY";
        bodyText.text = "Hello " + ownerName + " please select an electronic mail from the list below..." +
            "\n 1 - " + docsTitle[0] +
            "\n 2 - " + docsTitle[1] +
            "\n 3 - " + docsTitle[2];
        footerText.text = "| Press [TAB] to power down terminal | \n| Press [BACKSPACE] to return to the Main Menu |";
    }

    void ShowInfoText()
    {
        computerStage = 4;
        headerText.text = "Mega Corp OS V2.63 | INTERNAL USE ONLY";
        bodyText.text = "This Page Shows the information on "+ownerName+"'s computer \n \nThis computer is running Mega Corp Systems Version 2.63 (Internal Only) \n \nMCS Q199 Processing Unit Running 50MHz | \n64KB RAM | 150MB HDD |";
        footerText.text = "| Press [TAB] to power down terminal | \n| Press [BACKSPACE] to return to the Main Menu |";
    }

    #endregion
}
