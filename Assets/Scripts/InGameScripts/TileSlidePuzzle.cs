using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSlidePuzzle : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 correctPosition;
    private SpriteRenderer _sprite;
    public int number;
    public int correctPlaced;
    public bool inRightPlace;
    
    void Awake()
    {
        correctPosition = transform.position;
        targetPosition = transform.position;
        _sprite = GetComponent<SpriteRenderer>();
        Debug.Log(correctPosition);
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        //Debug.Log(correctPosition);
        if (targetPosition == correctPosition)
        {
            
            _sprite.color = Color.green;
            inRightPlace = true;
            
        }

        else
        {
            _sprite.color = Color.white;
            inRightPlace = false;            
        }
    }
}
