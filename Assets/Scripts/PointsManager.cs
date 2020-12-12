using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PointsManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text multiplierText;
    public GameObject sword;
    public GameObject resetZone;

    public int currentScore;
    public int pointsPerPellet = 100;
    public int totalHits = 0;
    public int totalMisses = 0;

    public int multiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    private bool oneTime = false;

    //private Sword swordComponent;
    private ResetZone resetZoneComponent;

    void Start()
    {
        //swordComponent = sword.GetComponent<Sword>();
        resetZoneComponent = resetZone.GetComponent<ResetZone>();

        currentScore = 0;
        multiplier = 1;

        scoreText.text = "0";
        multiplierText.text = "1x";
    }

    // Update is called once per frame
    void Update()
    {
        if(Sword.pelletHit == true)
        {
            if (!oneTime)
            {
                if (multiplierThresholds.Length > multiplier - 1)
                {
                    multiplierTracker++;

                    if (multiplierTracker >= multiplierThresholds[multiplier - 1])
                    {
                        multiplierTracker = 0;
                        multiplier++;

                        multiplierText.text = multiplier.ToString() + "x";
                    }
                }

                currentScore += 100 * multiplier;
                totalHits++;
                scoreText.text = currentScore.ToString();

                oneTime = true;

                StartCoroutine(ChangeOneTimeValue());
            }
        }

        PelletMissed();
    }

    public void PelletMissed()
    {
        if(resetZoneComponent.pelletMissed)
        {
            multiplier = 1;
            multiplierTracker = 0;
            totalMisses++;

            multiplierText.text = multiplier.ToString() + "x";
        }
    }

    IEnumerator ChangeOneTimeValue()
    {
        yield return new WaitForSeconds(0.0001f);
        oneTime = false;
    }
}
