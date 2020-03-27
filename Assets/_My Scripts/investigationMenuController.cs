using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class investigationMenuController : MonoBehaviour {

    public GameObject investigationMenu;
    public Text headerText;
    public Text bodyText;
    public Text footerText;
    public Text pageNumberText;

    int pageNumber = 0;

    bool investigationMenuActive;

    string[] investigationTitle = new string[10] { "Contents", "Inital Crime Scene Report", "File - Trevor Collins", "File - Cristiano Santos", "File - Rory Stirling", "File - Wayne Gavin", "File - Roy Black", "File - Nancy Washington", "File - Linda Terry", "Evidence Found" };
    string[] investigationContents = new string[10] { "0 - Contents\n \n1 - Inital Crime Scene Report\n \n2 - File - Trevor Collins\n \n3 - File - Cristiano Santos\n \n4 - File - Rory Stirling\n \n5 - File - Wayne Gavin\n \n6 - File - Roy Black\n \n7 - File - Nancy Washington\n \n8 - File - Linda Terry\n \n9 - Evidence Found",
        "", "", "", "", "", "", "", "", "" };
    string[] investigationFooter = new string[10] { "", "", "", "", "", "", "", "", "", "" };

    // Use this for initialization
    void Start ()
    {
        investigationMenuActive = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        InvestigationPanelControls();

        if (!investigationMenuActive && Input.GetKey(KeyCode.I))
        {
            Debug.Log("Button Pressed");
            OpenPanel();
        }

        if (pageNumber < 0)
        {
            pageNumber = 0;
        }
        if (pageNumber > 9)
        {
            pageNumber = 9;
        }
    }

    void OpenPanel()
    {
        pageNumber = 0;
        investigationMenu.SetActive(true);
        Time.timeScale = 0;

        investigationMenuActive = true;

        AssignPageContents();
    }

    void ClosePanel()
    {
        investigationMenu.SetActive(false);
        Time.timeScale = 1;

        investigationMenuActive = false;
    }

    void IncreasePage()
    {
        if (pageNumber < 9) //PAGE MAX, REASSIGN THIS VALUE TO REFLECT WHAT THE ACTUAL MAX IS
        {
            pageNumber++;

            headerText.text = investigationTitle[pageNumber];
            bodyText.text = investigationContents[pageNumber];
            //footerText.text = investigationFooter[pageNumber];
            pageNumberText.text = "" + pageNumber;
        }
        /*else
        {
            pageNumber = 0;
        }*/

        //AssignPageContents();
    }

    void DecreasePage()
    {
        if (pageNumber > 0)
        {
            pageNumber--;

            headerText.text = investigationTitle[pageNumber];
            bodyText.text = investigationContents[pageNumber];
            //footerText.text = investigationFooter[pageNumber];
            pageNumberText.text = "" + pageNumber;
        }
        /*else
        {
            pageNumber = 10; //PAGE MAX, REASSIGN THIS VALUE TO REFLECT WHAT THE ACTUAL MAX IS
        }*/

        //AssignPageContents();
    }

    void AssignPageContents()
    {
        headerText.text = investigationTitle[pageNumber];
        bodyText.text = investigationContents[pageNumber];
        footerText.text = "Use the Arrow Keys to change page \nPress [TAB] to close ";
        pageNumberText.text = ""+pageNumber;
    }

    void InvestigationPanelControls()
    {
        //control to activate panel
       /* if (!investigationMenuActive && Input.GetKey(KeyCode.I))
        {
            OpenPanel();
        } */

        //controls when the panel is active

        if (investigationMenuActive)
        {
            if (Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.I))
            {
                ClosePanel();
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                IncreasePage();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                DecreasePage();
            }
        }
    }

    
}
