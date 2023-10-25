using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour
{
    public GameObject retryMenu;
    private GameMaster gm;
    private Rigidbody2D rb;
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        HealthManager.onPlayerDeath += EnableRetryMenu;      
    }
    private void OnDisable()
    {
        HealthManager.onPlayerDeath -= EnableRetryMenu;
    }
    public void EnableRetryMenu ()
    {
        retryMenu.SetActive(true);
    }
    public void DisableRetryMenu ()
    {
        retryMenu.SetActive(false);
    }
    public void Respawn()
    {
        HealthManager.healthAmount = 15000f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
