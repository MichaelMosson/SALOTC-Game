using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeFinder : MonoBehaviour
{

    public Transform other;
    public float range;
    public bool inRange;
    float dist;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        getDistance();
        //Debug.Log(dist);

        if (range > dist)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }

    void getDistance()
    {
        dist = Vector3.Distance(other.position, vp_LocalPlayer.Position);
    }
}
