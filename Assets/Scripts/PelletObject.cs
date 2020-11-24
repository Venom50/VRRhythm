using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletObject : MonoBehaviour
{

    public bool canBeBlocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword")
        {
            canBeBlocked = true;
            Destroy(gameObject);
        }
        else if(other.tag == "ResetZone")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sword")
        {
            canBeBlocked = false;
        }
    }
}
