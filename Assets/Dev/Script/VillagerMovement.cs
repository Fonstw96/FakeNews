﻿using System.Collections;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float fWalkingSpeed = .1f;
    public int iDirection = 0;

    private Animator anim;
    public GameObject character;

    void Start ()
    {
        // Coroutines run alongside any other process
        StartCoroutine("WalkTurn");

        anim = character.GetComponent<Animator>();

        anim.Play("VillagerIdle");
    }

    void Update ()
    {
        // Walk in the properly set direction
        switch (iDirection)
        {
            case 0:   // Up
                transform.Translate(0, 0, fWalkingSpeed);
                break;
            case 1:   // Right
                transform.Translate(fWalkingSpeed, 0, 0);
                anim.Play("VillagerRight");
                break;
            case 2:   // Down
                transform.Translate(0, 0, -fWalkingSpeed);
                break;
            case 3:   // Left
                transform.Translate(-fWalkingSpeed, 0, 0);
                anim.Play("VillagerLeft");
                break;
        }
	}

    // The actual function to run as a coroutine
    private IEnumerator WalkTurn()
    {
        // The following thing always runs (being a coroutine, the following thing always runs alongside the rest)
        while (true)
        {
            // "yield" basically means "wait", and here we wait between half a second and two seconds before we continue
            yield return new WaitForSeconds(Random.Range(.5f, 2));

            // Actually going into a different direction
            iDirection = Random.Range(0, 4);
        }
    }





}
