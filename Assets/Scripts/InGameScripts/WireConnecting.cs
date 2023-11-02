using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WireConnecting : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    private void Start()
    {
        int rand = Random.Range(0,rotations.Length);
        transform.eulerAngles = new Vector3(0,0,rotations[rand]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
    }

    private void OnMouseDown()
    {
    }
}
