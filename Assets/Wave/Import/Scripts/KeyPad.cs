using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    [SerializeField] private string Answer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Delete()
    {
        Ans.text = string.Empty;
    }

    public void Execute()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Correct";
            Debug.Log("Open");
        }

        else
        {
            Ans.text = "Incorrect";
        }
    }
}
