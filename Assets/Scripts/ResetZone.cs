using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetZone : MonoBehaviour
{
    public bool pelletMissed = false;
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
        if (other.tag == "Pellet")
        {
            pelletMissed = true;
            Debug.Log("Missed");

            Destroy(other.gameObject);
            StartCoroutine(ChangeMissedValue());
        }
    }

    IEnumerator ChangeMissedValue()
    {
        yield return new WaitForSeconds(0.0000001f);
        pelletMissed = false;
    }
}
