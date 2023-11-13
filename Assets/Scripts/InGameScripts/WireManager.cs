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

    public GameObject lockCanvas;
    public bool interactable = false;
    public GameObject prefab;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void CorrectMove()
    {
        correctWires += 1;

        Debug.Log("correct move");

        if (correctWires == totalWires)
        {
            Debug.Log("Yay win");
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }

    public void WrongMove() 
    {
        correctWires -= 1;
    }

    public void Interact()
    {
        if (interactable)
            lockCanvas.SetActive(true);
    }

    public void StopInteract()
    {
        lockCanvas.SetActive(false);
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
