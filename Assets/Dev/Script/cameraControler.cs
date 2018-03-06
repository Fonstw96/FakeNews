﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = target.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position - offset;

        transform.LookAt(target);

    }

}
