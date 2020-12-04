using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject sword;

    private bool oneTime = false;

    //private Sword swordComponent;

    public int currentScore = 0;
    public int multiplier = 1;
    public int pointsPerPellet = 100;
    void Start()
    {
        //swordComponent = sword.GetComponent<Sword>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Sword.pelletHit == true)
        {
            if (!oneTime)
            {
                currentScore += 100;
                scoreText.text = currentScore.ToString();
                oneTime = true;
                StartCoroutine(ChangeOneTimeValue());
            }
        }
    }

    IEnumerator ChangeOneTimeValue()
    {
        yield return new WaitForSeconds(0.0001f);
        oneTime = false;
    }
}
