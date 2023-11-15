using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text cointext;
    public int currentCoins = 0;
    public int totalCoins = 8;

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
        
    }
}
