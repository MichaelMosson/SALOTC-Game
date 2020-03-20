using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlockingKey : MonoBehaviour {

    public Text interactionText;

    public GameObject key;
    public GameObject lockedDoor;
    public GameObject unlockedDoor;

    private rangeFinder rangefinder;

    bool activatable;

    // Use this for initialization
    void Start ()
    {
        rangefinder = GetComponent<rangeFinder>();

        activatable = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (activatable && Input.GetKey(KeyCode.E))
        {
            pickupKey();
        }
	}

    //Called when the mouse enters the box collider of the gameobject
    private void OnMouseEnter()
    {
        if (rangefinder.inRange)
        {
            interactionText.text = "[E] Pick up";

            activatable = true;
        }
    }

    //Called when the mouse hovers over the gameobject
    private void OnMouseOver()
    {
        if (rangefinder.inRange)
        {
            interactionText.text = "[E] Pick up";

            activatable = true;
        }
        else
        {
            interactionText.text = "";

            activatable = false;
        }
    }

    //Called when the mouse exits the box collider
    private void OnMouseExit()
    {
        interactionText.text = "";

        activatable = false;
    }

    void pickupKey()
    {
        //disable key
        key.gameObject.SetActive(false);

        //disable locked door
        lockedDoor.gameObject.SetActive(false);

        //enable unlocked door
        unlockedDoor.gameObject.SetActive(true);

        interactionText.text = "";
    }


}
