using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Timer timer1;

    void Start()
    {
        timer1.setDuration(20).Begin();
    }
}
