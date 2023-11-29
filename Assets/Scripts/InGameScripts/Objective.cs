using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public float timeToFade = 2f;
    public float timeToAppear;
    [SerializeField] private CanvasGroup myUIGroup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;

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

        if (timeToFade > 0 && timeToAppear <= 0)
        {
            timeToFade -= Time.deltaTime;
        }

        if (timeToAppear <= 0)
        {
            fadeIn = true;
            fadeOut = false;
        }

        if (timeToFade <= 0)
        {
            fadeIn = false;
            fadeOut = true;
        }

        if (fadeIn)
        {
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if (myUIGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (myUIGroup.alpha >= 0)
            {
                myUIGroup.alpha -= Time.deltaTime;
                if (myUIGroup.alpha >= 0)
                {
                    fadeOut = false;
                }
            }
        }

    }
}
