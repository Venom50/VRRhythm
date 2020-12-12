using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawner : MonoBehaviour
{
    public GameObject cuttingPelletObject;
    public GameObject pointsManager;
    public AudioSource audioSource;
    public Transform cuttingPelletPoint;
    public GameObject[] pellets;

    // 0 - left; 1 - up; 2 - right
    public Transform[] points;
    public float beat;
    public float songInSeconds;
    public int spawnedPellets = 0;

    public float percentageScore = 0f;

    // UI
    public GameObject resultsScreen;
    public GameObject uiScreen;
    public TMP_Text hitsText;
    public TMP_Text missesText;
    public TMP_Text percentageText;
    public TMP_Text finalText;

    private PointsManager pointsManagerComponent;

    private float timer;
    private float cutTimer;
    private bool results = false;

    // 0 - leftPellet; 1 - upperPellet; 2 - rightPellet
    private int randomPellet;
    private int randomTimeCut = 15;
    private bool isSpawningPellets = true;

    // Start is called before the first frame update
    void Start()
    {
        pointsManagerComponent = pointsManager.GetComponent<PointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        songInSeconds -= Time.deltaTime;  

        if (songInSeconds <= 0f)
            isSpawningPellets = false;

        if (timer>beat && !results && isSpawningPellets)
        {
            randomPellet = Random.Range(0, 3);
            if(randomPellet == 0)
            {
                GameObject leftPellet = Instantiate(pellets[randomPellet], points[randomPellet]);
                leftPellet.transform.localPosition = Vector3.zero;

                spawnedPellets++;
            }
            else if(randomPellet == 1)
            {
                GameObject upperPellet = Instantiate(pellets[randomPellet], points[randomPellet]);
                upperPellet.transform.localPosition = Vector3.zero;

                spawnedPellets++;
            }
            else if(randomPellet == 2)
            {
                GameObject rightPellet = Instantiate(pellets[randomPellet], points[randomPellet]);
                rightPellet.transform.localPosition = Vector3.zero;

                spawnedPellets++;
            }

            timer -= beat;

        }

        if(cutTimer > beat * randomTimeCut && !results && isSpawningPellets)
        {
            GameObject cuttingPellet = Instantiate(cuttingPelletObject, cuttingPelletPoint);
            cuttingPellet.transform.localPosition = Vector3.zero;
            cuttingPellet.transform.Rotate(transform.forward, 45 * Random.Range(0, 8));

            spawnedPellets++;

            cutTimer -= beat * randomTimeCut;
            randomTimeCut = Random.Range(5, 10);
        }

        if(!audioSource.isPlaying && !resultsScreen.activeInHierarchy)
        {
            hitsText.text = pointsManagerComponent.totalHits.ToString();
            missesText.text = pointsManagerComponent.totalMisses.ToString();

            percentageScore = ((float)pointsManagerComponent.totalHits / (float)spawnedPellets) * 100f;
            percentageText.text = percentageScore.ToString("0.0") + "%";
            finalText.text = pointsManagerComponent.currentScore.ToString();

            uiScreen.SetActive(false);
            resultsScreen.SetActive(true);
            results = true;
        }

        timer += Time.deltaTime;
        cutTimer += Time.deltaTime;
        
    }
}
