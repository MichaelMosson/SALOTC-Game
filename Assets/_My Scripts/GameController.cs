using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //TODO add another text specifically to tell the player that the game is paused
    public bool gamePaused;
    public bool investigationMenuActive;
    public bool inTerminal;
    

	// Use this for initialization
	void Start () {
        gamePaused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1.0)
            {
                //Below commented out code has been moved to pauseController.cs
                //Time.timeScale = 0;
                //Debug.Log("Game Paused");
                gamePaused = true;
                

            }
            if(Time.timeScale == 0)
            {
                //Below commented out code has been moved to pauseController.cs
                //Time.timeScale = 1;
                //Debug.Log("Game Unpaused");
                gamePaused = false;
                
            }
                
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Time.timeScale == 1)
            {
                investigationMenuActive = true;
            }
            else
            {
                investigationMenuActive = false;
            }
        }
    }

    public void InvestigationMenuControlScheme()
    {
        //Exit Investigation Menu
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            investigationMenuActive = false;
        }
    }
}
