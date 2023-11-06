using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WireManager : MonoBehaviour
{
    public GameObject WiresHolder;
    public GameObject[] Wires;

    [SerializeField] int totalWires = 0;

    [SerializeField] int correctWires = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalWires = WiresHolder.transform.childCount;

        Wires = new GameObject[totalWires];

        for (int i = 0; i < Wires.Length; i++)
        {
            Wires[i] = WiresHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CorrectMove()
    {
        correctWires += 1;

        Debug.Log("correct move");

        if (correctWires == totalWires)
        {
            Debug.Log("Yay win");
        }
    }

    public void WrongMove() 
    {
        correctWires -= 1;
    }
}
