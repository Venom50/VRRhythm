using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cuttingPelletObject;
    public Transform cuttingPelletPoint;
    public GameObject[] pellets;
    // 0 - left; 1 - up; 2 - right
    public Transform[] points;
    public float beat;

    private float timer;
    private float cutTimer;
    // 0 - leftPellet; 1 - upperPellet; 2 - rightPellet
    private int randomPellet;
    private int randomTimeCut = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>beat)
        {
            randomPellet = Random.Range(0, 3);
            if(randomPellet == 0)
            {
                GameObject leftPellet = Instantiate(pellets[randomPellet], points[randomPellet]);
                leftPellet.transform.localPosition = Vector3.zero;
            }
            else if(randomPellet == 1)
            {
                GameObject upperPellet = Instantiate(pellets[randomPellet], points[randomPellet]);
                upperPellet.transform.localPosition = Vector3.zero;
            }
            else if(randomPellet == 2)
            {
                GameObject rightPellet = Instantiate(pellets[randomPellet], points[randomPellet]);
                rightPellet.transform.localPosition = Vector3.zero;
            }

            timer -= beat;

        }

        if(cutTimer > beat * randomTimeCut)
        {
            GameObject cuttingPellet = Instantiate(cuttingPelletObject, cuttingPelletPoint);
            cuttingPellet.transform.localPosition = Vector3.zero;
            cuttingPellet.transform.Rotate(transform.forward, 45 * Random.Range(0, 8));

            cutTimer -= beat * randomTimeCut;
            randomTimeCut = Random.Range(5, 10);
        }

        timer += Time.deltaTime;
        cutTimer += Time.deltaTime;
    }
}
