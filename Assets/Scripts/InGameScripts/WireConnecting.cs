using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WireConnecting : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField] bool isPlaced = false;
    private RectTransform rectTransform;

    int PossibleRots = 1;

    WireManager wireManager;

    private void Awake()
    {
        wireManager = GameObject.Find("GameManager").GetComponent<WireManager>();
    }

    private void Start()
    {
        PossibleRots = correctRotation.Length;
        rectTransform = GetComponent<RectTransform>();
        int rand = Random.Range(0,rotations.Length);
        rectTransform.eulerAngles = new Vector3(0,0,rotations[rand]);

        if (PossibleRots > 1)
        {
            if (rectTransform.eulerAngles.z <= correctRotation[0] + 5 && rectTransform.eulerAngles.z >= correctRotation[0] - 5 || rectTransform.eulerAngles.z <= correctRotation[1] + 5 && rectTransform.eulerAngles.z >= correctRotation[1] - 5)
            {
                isPlaced = true;
                wireManager.CorrectMove();
            }

            else
            {
                if (rectTransform.eulerAngles.z <= correctRotation[0] + 5 && rectTransform.eulerAngles.z >= correctRotation[0] - 5)
                {
                    isPlaced = true;
                    wireManager.CorrectMove();
                }
            }
        }
    }

    private void Update()
    {

    }

    private void OnMouseDown()
    {
    }

    public void Rotate()
    {
        rectTransform.Rotate(new Vector3(0, 0, 90));

        Debug.Log(rectTransform.eulerAngles.z);

        if (PossibleRots > 1)
        {
            if (rectTransform.eulerAngles.z <= correctRotation[0] + 5 && rectTransform.eulerAngles.z >= correctRotation[0] - 5 || rectTransform.eulerAngles.z <= correctRotation[1] + 5 && rectTransform.eulerAngles.z >= correctRotation[1] - 5 && isPlaced == false)
            {
                isPlaced = true;
                wireManager.CorrectMove();
            }

            else if (isPlaced == true)
            {
                isPlaced = false;
                wireManager.WrongMove();
            }
        }

        else
        {
            if (rectTransform.eulerAngles.z <= correctRotation[0] + 5 && rectTransform.eulerAngles.z >= correctRotation[0] - 5 && isPlaced == false)
            {
                isPlaced = true;
                wireManager.CorrectMove();
            }

            else if (isPlaced == true)
            {
                isPlaced = false;
                wireManager.WrongMove();
            }
        }
    }
}
