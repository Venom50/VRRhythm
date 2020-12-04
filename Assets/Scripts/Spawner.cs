using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawner : MonoBehaviour
{
    public GameObject cuttingPelletObject;
    public Transform cuttingPelletPoint;
    public GameObject[] pellets;
    // 0 - left; 1 - up; 2 - right
    public Transform[] points;
    public float beat;

    //public int currentScore = 0;
    //public int multiplier = 1;

    //public TMP_Text scoreText;

    //private PelletObject leftPelletObject;
    //private PelletObject upPelletObject;
    //private PelletObject rightPelletObject;

    private float timer;
    private float cutTimer;
    // 0 - leftPellet; 1 - upperPellet; 2 - rightPellet
    private int randomPellet;
    private int randomTimeCut = 15;

    // Start is called before the first frame update
    void Start()
    {
        /*leftPelletObject = pellets[0].GetComponent<PelletObject>();
        upPelletObject = pellets[1].GetComponent<PelletObject>();
        rightPelletObject = pellets[2].GetComponent<PelletObject>();*/
        //scoreText.text = currentScore.ToString();
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
                //leftPelletObject = leftPellet.GetComponent<PelletObject>();
                /*if(leftPelletObject.hit == true)
                {
                    currentScore += 100;
                    scoreText.text = currentScore.ToString();
                }*/
            }
            else if(randomPellet == 1)
            {
                GameObject upperPellet = Instantiate(pellets[randomPellet], points[randomPellet]);
                upperPellet.transform.localPosition = Vector3.zero;
                //upPelletObject = upperPellet.GetComponent<PelletObject>();
                /*if (upPelletObject.hit)
                {
                    currentScore += 100;
                    scoreText.text = currentScore.ToString();
                }*/
            }
            else if(randomPellet == 2)
            {
                GameObject rightPellet = Instantiate(pellets[randomPellet], points[randomPellet]);
                rightPellet.transform.localPosition = Vector3.zero;
                //rightPelletObject = rightPellet.GetComponent<PelletObject>();
                /*if (rightPelletObject.hit)
                {
                    currentScore += 100;
                    scoreText.text = currentScore.ToString();
                }*/
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

        /*if (leftPelletObject != null)
        {
            if (leftPelletObject.hit == true)
            {
                currentScore += 100;
                scoreText.text = currentScore.ToString();
            }
        }

        if (upPelletObject != null)
        {
            if (upPelletObject.hit == true)
            {
                currentScore += 100;
                scoreText.text = currentScore.ToString();
            }
        }

        if (rightPelletObject != null)
        {
            if (rightPelletObject.hit == true)
            {
                currentScore += 100;
                scoreText.text = currentScore.ToString();
            }
        }

        if (rightPelletObject != null && upPelletObject != null && leftPelletObject != null)
        {
            if (rightPelletObject.hit || upPelletObject.hit || leftPelletObject.hit)
            {
                currentScore += 100;
                scoreText.text = currentScore.ToString();
            }
        }*/
    }
}
