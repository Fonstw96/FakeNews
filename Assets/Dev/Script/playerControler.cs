﻿using UnityEngine;

public class playerControler : MonoBehaviour
{
    public int iPlayerNo = 1;
    public float moveSpeed;
    public Rigidbody theRB;

    public GameObject character;
    private Animator anim1;
    private Animator anim2;
    //public float jumpForce;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        anim1 = character.GetComponent<Animator>();
        anim2 = character.GetComponent<Animator>();

        anim1.Play("Idle");
        anim2.Play("Player2Idle");

    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector3(Input.GetAxis("Horizontal" + iPlayerNo) * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical" + iPlayerNo) * moveSpeed);

        //if (Input.GetButtonDown("Jump"))
        //{
        //    theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        //}

        if (Input.GetAxis("Vertical" + iPlayerNo) > 0)
        {
            //Debug.Log("Up");
            anim1.Play("WalkFront");
            anim2.Play("Player2Front");
        }

        else if (Input.GetAxis("Vertical" + iPlayerNo) < 0)
        {
            //Debug.Log("Down");
            anim1.Play("WalkFront");
            anim2.Play("Player2Front");
        }

        else if (Input.GetAxis("Horizontal" + iPlayerNo) > 0)
        {
            //Debug.Log("right");
            anim1.Play("WalkRight");
            anim2.Play("Player2Right");

        }

        else if (Input.GetAxis("Horizontal" + iPlayerNo) < 0)
        {
            //Debug.Log("left");
            anim1.Play("WalkLeft");
            anim2.Play("Player2Left");
        }

    }
}
