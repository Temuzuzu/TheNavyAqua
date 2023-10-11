using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public static float healthAmount = 6000f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
        if (healthAmount < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void TakeDamage()
    {
        healthAmount--;
        healthBar.fillAmount = healthAmount/6000;
    }

}
