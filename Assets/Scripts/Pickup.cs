using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slot.Length; i++)
            {
                if (inventory.isfull[i] == false)
                {
                    //Item can add in inventory
                    inventory.isfull[i] = true;
                    Instantiate(itemButton, inventory.slot[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
