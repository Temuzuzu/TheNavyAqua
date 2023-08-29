using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool isOpen;
    //public Animator animator;
    
    public void OpenChest()
    {
        if(!isOpen)
        {
            isOpen = true;
            Debug.Log("Yay");
            //animator.SetBool("isOpen", isOpen);
        }
    }
}
