using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingPellet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyPellet());
    }

    IEnumerator DestroyPellet()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
