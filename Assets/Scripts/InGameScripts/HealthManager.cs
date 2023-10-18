using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static event Action onPlayerDeath;
    public Image healthBar;
    public static float healthAmount = 15000f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
        if (healthAmount < 0)
        {
            onPlayerDeath?.Invoke();
        }
    }
    public void TakeDamage()
    {    
        healthAmount--;
        healthBar.fillAmount = healthAmount/15000;
    }

}
