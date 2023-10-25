using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice_puzzle : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    [SerializeField] private float distance;
    private Camera _camera;
    public CoinCounter coinCounter;
    private bool hasEnoughCoins = false;
    public GameObject lockCanvas;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinCounter.currentCoins >= 8)
        {
            hasEnoughCoins = true;
            lockCanvas.SetActive(true);
        }

        if (hasEnoughCoins == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit)
                {
                    if (Vector2.Distance(emptySpace.position, hit.transform.position) < distance)
                    {
                        Vector2 lastEmptyPosition = emptySpace.position;
                        emptySpace.position = hit.transform.position;
                        hit.transform.position = lastEmptyPosition;
                    }
                }
            }
        }
    }
}
