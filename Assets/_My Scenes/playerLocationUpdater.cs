using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLocationUpdater : MonoBehaviour {

    public Text playerLocationText;
    public string location;

    // Use this for initialization
    void Start()
    {
        playerLocationText.text = "Reception - 23rd Floor";
    }

    private void OnTriggerEnter(Collider other)
    {
        playerLocationText.text = location;
    }

    //Fade text out after certain amount of time
}
