using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingPellet : MonoBehaviour
{
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
