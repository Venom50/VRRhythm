using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public LayerMask cuttingPelletLayer;
    private Vector3 previousPos;
    //private float enoughSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        //Rigidbody rb = GetComponent<Rigidbody>();
        //Vector3 velocity = rb.velocity;
        if (Physics.Raycast(transform.position, transform.up, out hit, 1, cuttingPelletLayer))
        {
            //  
            //  && velocity.magnitude >= enoughSpeed
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130 || Vector3.Angle(transform.position - previousPos, -hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
            }
        }
        previousPos = transform.position;
    }
}
