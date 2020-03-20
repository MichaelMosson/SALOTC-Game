using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class investigationMenuController : MonoBehaviour {

    private GameController gameController;

    public GameObject investigationMenu;
    public Text headerText;
    public Text bodyText;
    int pageNumber;

	// Use this for initialization
	void Start ()
    {
        pageNumber = 1;
        gameController = GetComponent<GameController>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        checkState();

        if (gameController.investigationMenuActive)
        {
            setText();
            gameController.InvestigationMenuControlScheme();
        }

    }

    public void checkState()
    {
        if (gameController.investigationMenuActive)
        {
            investigationMenu.SetActive(true);                
        }
        if (!gameController.investigationMenuActive)
        {
            investigationMenu.SetActive(false);
        }
    }

    public void setText()
    {

    }

    
}
