using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuggetLock : MonoBehaviour
{
    public bool interactable = false;
    public GameObject lockCanvas;
    public Text[] text;

    public string password;
    public string[] lockCharaterChoices;
    public int[] _lockCharaterNumber;
    private string _insertedPassword;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        _lockCharaterNumber = new int[password.Length];
    }

    public void ChangeInsertedPassword(int number)
    {
        _lockCharaterNumber[number]++;
        if (_lockCharaterNumber[number] >= lockCharaterChoices[number].Length)
        {
            _lockCharaterNumber[number] = 0;
        }

        CheckPassword();
        UpdateUI();
    }

    public void CheckPassword()
    {
        int pass_len = password.Length;
        _insertedPassword = "";
        for(int i = 0; i < pass_len; i++)
        {
            _insertedPassword += lockCharaterChoices[i][_lockCharaterNumber[i]].ToString();
        }

        if (password == _insertedPassword)
        {
            Unlock();
        }
    }

    public void Unlock()
    {
        Debug.Log("Unlocked");
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public void UpdateUI()
    {
        int len = text.Length;
        for( int i = 0; i < len; i++)
        {
            text[i].text = lockCharaterChoices[i][_lockCharaterNumber[i]].ToString();
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
    }

    public void Interact()
    {
        if(interactable)
            lockCanvas.SetActive(true);
    }

    public void StopInteract()
    {
        lockCanvas.SetActive(false);
    }
}
