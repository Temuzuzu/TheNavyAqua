using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamefinished : MonoBehaviour
{
    private bool isFinished = false;
    public bool interactable = false;
    public CoinCounter coinCounter;
    public GameObject sprite;
    private void Update()
    {
        if (coinCounter.currentCoins >= 8)
        {
            isFinished = true;
            sprite.SetActive(true);
        }

        if (interactable == true)
        {
            if (isFinished == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
    }
}
