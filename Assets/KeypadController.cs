using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour {

    private rangeFinder RangeFinder;

    public GameObject keypadPanel;
    public GameObject inputBox;
    public InputField keypadInput;
    public Text interactionText;

    public Text inputText;

    public GameObject lockedDoor;
    public GameObject unlockedDoor;

    bool interacting;
    bool interactable;

    string inputtedText;

    string keypadCode = "1776";

	// Use this for initialization
	void Start ()
    {

    RangeFinder = GetComponent<rangeFinder>();
    interacting = false;
    interactable = true;
    inputtedText = "";
        
	}

    // Update is called once per frame
    void Update()
    {
        if (interacting)
        {
            KeypadControls();
        }
    }

    #region Physical Interaction

    private void OnMouseOver()
    {
        if (RangeFinder.inRange && !interacting && interactable)
        {
            interactionText.text = "[E] Activate";

            if (Input.GetKey(KeyCode.E))
            {
                ActivatePanel();
            }
        }

        if (!RangeFinder.inRange || interacting)
        {
            interactionText.text = "";
        }
    }

    private void OnMouseExit()
    {
        interactionText.text = "";
    }

    #endregion

    void ActivatePanel()
    {
        interacting = true;
        keypadPanel.SetActive(true);
        selectIputBox();
        Time.timeScale = 0;
    }

    public void selectIputBox()
    {
        inputBox.gameObject.SetActive(true);
        //set input box as the default input field
        keypadInput.Select();
    }

    void DeactivatePanel()
    {
        interacting = false;
        keypadPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void UnlockDoor()
    {
        lockedDoor.SetActive(false);

        unlockedDoor.SetActive(true);
    }

    void KeypadControls()
    {
        if (Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.Escape))
        {
            DeactivatePanel();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        inputtedText = inputText.text;

        Debug.Log(inputtedText + " entered into the Keypad");

        //clears the input text
        inputText.text = "";

        if (inputtedText == keypadCode)
        {
            AcceptInput();
        }
        if(inputtedText != keypadCode)
        {
            RejectInput();
        }
    }

    void AcceptInput()
    {
        UnlockDoor();
        interactable = false;
        DeactivatePanel();
        interactionText.text = "Code has been accepted!";
        StartCoroutine("TextTimer");
    }

    void RejectInput()
    {
        DeactivatePanel();
        interactionText.text = "Code has been rejected!";
        StartCoroutine("TextTimer");
        inputText.text = "";
    }

    IEnumerator TextTimer()
    {
        yield return new WaitForSeconds(5f);
        interactionText.text = "";
        StopCoroutine();
    }

    void StopCoroutine()
    {
        StopCoroutine("TextTimer");
    }

}
