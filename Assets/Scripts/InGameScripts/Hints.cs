using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Hints : MonoBehaviour
{
    public GameObject hint;
    public bool playerIsClosed = false;
    private void Update()
    {
        if (playerIsClosed == true)
        {
            hint.SetActive(true);
        }
        else
        {
            hint.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            playerIsClosed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClosed = false;
        }
    }
}
