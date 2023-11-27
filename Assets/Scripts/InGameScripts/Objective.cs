using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public GameObject WhateverTextThingy;  //Add reference to UI Text here via the inspector
    public float timeToAppear = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToAppear > 0)
        {
            timeToAppear -= Time.deltaTime;
        }

        if (timeToAppear <= 0)
        {
            WhateverTextThingy.SetActive(false);
        }
    }
}
