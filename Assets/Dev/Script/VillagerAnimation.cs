using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerAnimation : MonoBehaviour
{
    public string sPlayerNo = "1";
    public GameObject character;
    private Animator anim;

    void Start()
    {
        anim = character.GetComponent<Animator>();

        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal" + sPlayerNo) > 0)
        {
            Debug.Log("right villager");
            anim.Play("VillagerRight");
        }

        if (Input.GetAxis("Horizontal" + sPlayerNo) < 0)
        {
            Debug.Log("left villager");
            anim.Play("VillagerLeft");
        }

    }
}
