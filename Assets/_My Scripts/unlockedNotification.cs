using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlockedNotification : MonoBehaviour {

    public Text interactionText;
    public string unlockMessage;
    public int count;

	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (count < 1)
        {
            interactionText.text = unlockMessage;

            count++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactionText.text = "";
    }
}
