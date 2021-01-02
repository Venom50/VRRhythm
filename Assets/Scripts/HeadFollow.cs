using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollow : MonoBehaviour
{
    public GameObject vrrig;
    public bool pelletHit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = vrrig.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dodge")
        {
            pelletHit = true;
            Debug.Log("Hit");

            StartCoroutine(ChangeHitValue());
        }
    }

    IEnumerator ChangeHitValue()
    {
        yield return new WaitForSeconds(0.0000001f);
        pelletHit = false;
        yield return new WaitForSeconds(5f);
        pelletHit = false;

    }
}
