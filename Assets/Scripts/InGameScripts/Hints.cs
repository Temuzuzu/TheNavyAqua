using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Hints : MonoBehaviour
{
    public GameObject HintText;
    public bool interactable = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
    public void Interact()
    {
        if (interactable)
            HintText.SetActive(true);
    }
    public void StopInteract()
    {
        HintText.SetActive(false);
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
