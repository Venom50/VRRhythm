using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public GameObject swordPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(swordPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
