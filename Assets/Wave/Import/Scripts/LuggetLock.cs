using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuggetLock : MonoBehaviour
{
    public bool interactable = true;
    public GameObject lockCanvas;
    public Text[] text;

    public string password;
    public string[] lockCharaterChoices;
    public int[] _lockCharaterNumber;
    private string _insertedPassword;

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
        
    }

    private void OnMouseDown()
    {
        Interact();
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
