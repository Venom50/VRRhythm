using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public LayerMask cuttingPelletLayer;
    private Vector3 previousPos;

    public static bool pelletHit = false;
    public static bool cuttingPelletHit = false;
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
                pelletHit = true;
                cuttingPelletHit = true;
                Destroy(hit.transform.gameObject);
                StartCoroutine(ChangeHitValue());
                StartCoroutine(SwitchCuttingPelletHitToFalse());
            }
        }
        previousPos = transform.position;


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pellet")
        {
            pelletHit = true;
            Debug.Log("Hit");
            
            Destroy(other.gameObject);
            StartCoroutine(ChangeHitValue());
        }
    }

    IEnumerator ChangeHitValue()
    {
        yield return new WaitForSeconds(0.0000001f);
        pelletHit = false;
    }

    IEnumerator SwitchCuttingPelletHitToFalse()
    {
        yield return new WaitForSeconds(0.1f);
        cuttingPelletHit = false;
    }
}
