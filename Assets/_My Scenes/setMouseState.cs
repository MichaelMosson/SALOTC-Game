using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMouseState : MonoBehaviour {

    private void Start()
    {
        lockMouse();
    }

    public void lockMouse()
    {
        //lock the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
        //Hide the cursor
        Cursor.visible = false;
    }

    public void freeMouse()
    {
        //Free the cursor from the middle of the screen
        Cursor.lockState = CursorLockMode.None;
        //Show the cursor
        Cursor.visible = true;
    }
}
