using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pellets;
    // 0 - left; 1 - up; 2 - right
    public Transform[] points;
    public float beat;

    private float timer;
    // 0 - leftPellet; 1 - upperPellet; 2 - rightPellet
    private int randomPellet;

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

        timer += Time.deltaTime;
    }
}
