using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text cointext;
    public int currentCoins = 0;
    public int totalCoins = 8;
    private bool isFinished = false;
    public bool interactable = false;
    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cointext.text = currentCoins.ToString() + "/" + totalCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        cointext.text = currentCoins.ToString() + "/" + totalCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCoins >= 8)
        {
            isFinished = true;
        }

        if (interactable == true)
        {
            if (isFinished == true) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
