using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : MonoBehaviour
{
    public GameObject spawner;

    private Animator animator;
    private Spawner spawnerComponent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spawnerComponent = spawner.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnerComponent.isSpawningPellets)
        {
            animator.SetBool("SpawningPellets", true);
        } else
        {
            animator.SetBool("SpawningPellets", false);
        }

        if(spawnerComponent.isDodgeSpawned)
        {
            animator.SetBool("DodgeSpawned", true);
        } else
        {
            animator.SetBool("DodgeSpawned", false);
        }

        if(Sword.cuttingPelletHit)
        {
            animator.SetBool("GetHit", true);
        } else
        {
            animator.SetBool("GetHit", false);
        }
    }
}
