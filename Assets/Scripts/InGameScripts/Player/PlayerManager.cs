using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keycount;
    public void PickupKey()
    {
        keycount++;
    }

    public void FixedUpdate()
    {
        
    }
}
