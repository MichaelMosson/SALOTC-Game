using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readerInteraction : MonoBehaviour {

    //Reference to the text which the player will be shown
    public Text headerText;
    public Text bodyText;

    public string headerContents;
    public string bodyContents;

    public GameObject pagePanel;

    //Noise effect variables
    public AudioClip pickupPaper;
    public AudioSource paperSFXSource;

    //Reference to the Interaction Text
    public Text interactText;

    //bool which denotes if the player is interacting with the note
    public bool interacting;

    //Reference to the range finder
    private rangeFinder rangefinder;

    // Use this for initialization
    void Start () {

        paperSFXSource.clip = pickupPaper;
        rangefinder = GetComponent<rangeFinder>();
        interacting = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (interacting && Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.Escape))
        {
            exitNote();
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
            interact();
            Debug.Log("Player attempts to interact with note");
        }
    }

    private void OnMouseExit()
    {
        if (rangefinder.inRange)
        {
            clearText();
        }
    }
    //clears the interaction text
    void clearText()
    {
        interactText.text = "";
        Debug.Log("interactText has been cleared");
    }

    #endregion

    #region interaction

    void interact()
    {

        interacting = true;
        Debug.Log("Note has been activated");

        //play audio clip
        paperSFXSource.Play();

        Time.timeScale = 0;
        Debug.Log("Game has been paused");

        pagePanel.SetActive(true);

        headerText.text = headerContents;
        bodyText.text = bodyContents;

        Debug.Log("Texts have been set");
    }

    void exitNote()
    {
        pagePanel.SetActive(false);
        interacting = false;
        Debug.Log("Page has been closed");

        Time.timeScale = 1;
        Debug.Log("Game has been restarted");
    }

    #endregion


}
