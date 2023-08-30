using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
