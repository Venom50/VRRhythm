using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class PelletObject : MonoBehaviour
{

    //public bool canBeBlocked;
    //public bool hit = false;
    //public bool missed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword")
        {
            canBeBlocked = true;
            hit = true;
            Destroy(gameObject);
        }
        else if(other.tag == "ResetZone")
        {
            missed = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sword")
        {
            canBeBlocked = false;
        }
    }*/
}
