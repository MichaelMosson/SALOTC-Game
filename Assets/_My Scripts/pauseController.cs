using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseController : MonoBehaviour {

    private GameController gameController;
    private setMouseState setmousestate;

    public GameObject pausePanel;
    public Text headerText;


	// Use this for initialization
	void Start () {

        gameController = GetComponent<GameController>();
        setmousestate = GetComponent<setMouseState>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameController.gamePaused)
        {
            Time.timeScale = 0;

            Debug.Log("Game Paused");

            pausePanel.SetActive(true);

            setmousestate.freeMouse();
            
        }
        if(!gameController.gamePaused && Input.GetKey(KeyCode.Escape)) //non pausing bug was here!!!!!!!!!!!!!!!!!!!
        {
            Time.timeScale = 1;

            Debug.Log("Game Unpaused");

            pausePanel.SetActive(false);

            setmousestate.lockMouse();
        }
		
	}
}
