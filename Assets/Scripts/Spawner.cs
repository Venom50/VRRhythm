using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject cuttingPelletObject;
    public GameObject dodgePelletObject;
    public GameObject pointsManager;
    public AudioSource audioSource;
    public Transform cuttingPelletPoint;
    public Transform dodgeLeftPelletPoint;
    public Transform dodgeRightPelletPoint;
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
    private float dodgeTimer;
    private bool results = false;

    // 0 - leftPellet; 1 - upperPellet; 2 - rightPellet
    private int randomPellet;
    private int randomTimeCut = 15;
    private int randomTimeDodge = 30;
    private int randomDodge;
    public bool isSpawningPellets = true;
    public bool isDodgeSpawned = false;

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

        if(dodgeTimer > beat * randomTimeDodge && !results && isSpawningPellets)
        {
            randomDodge = Random.Range(0, 2);
            if(randomDodge == 0)
            {
                GameObject dodgePellet = Instantiate(dodgePelletObject, dodgeLeftPelletPoint);
                dodgePellet.transform.localPosition = Vector3.zero;
                dodgePellet.transform.Rotate(transform.forward, 30);

                dodgeTimer -= beat * randomTimeDodge;
                randomTimeDodge = Random.Range(20, 30);
            }
            else if(randomDodge == 1)
            {
                GameObject dodgePellet = Instantiate(dodgePelletObject, dodgeRightPelletPoint);
                dodgePellet.transform.localPosition = Vector3.zero;
                dodgePellet.transform.Rotate(transform.forward, -30);

                dodgeTimer -= beat * randomTimeDodge;
                randomTimeDodge = Random.Range(20, 30);
            }
            isDodgeSpawned = true;
            StartCoroutine(SwitchDodgeBoolToFalse());
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
            StartCoroutine(LoadMenuScene());
        }

        timer += Time.deltaTime;
        cutTimer += Time.deltaTime;
        dodgeTimer += Time.deltaTime;
    }

    IEnumerator LoadMenuScene()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator SwitchDodgeBoolToFalse()
    {
        yield return new WaitForSeconds(0.3f);
        isDodgeSpawned = false;
    }
}
