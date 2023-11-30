using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slice_puzzle : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    [SerializeField] private float distance;
    private Camera _camera;
    public CoinCounter coinCounter;
    private bool hasEnoughCoins = false;
    public GameObject lockCanvas;
    [SerializeField] TileSlidePuzzle[] tiles;
    private int emptySpaceIndex = 8;
    private bool _isfinished;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (coinCounter.currentCoins >= 8)
        {
            hasEnoughCoins = true;
            lockCanvas.SetActive(true);
        }
        if (coinCounter.currentCoins < 8)
        {
            hasEnoughCoins = true;
            lockCanvas.SetActive(false);
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
                        TileSlidePuzzle thisTile = hit.transform.GetComponent<TileSlidePuzzle>();
                        emptySpace.position = thisTile.targetPosition;
                        thisTile.targetPosition = lastEmptyPosition;
                        int tileIndex = FindIndex(thisTile);
                        tiles[emptySpaceIndex] = tiles[tileIndex];
                        tiles[tileIndex] = null;
                        emptySpaceIndex = tileIndex;

                    }
                }
            }
        }

        if (!_isfinished)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {

                    if (a.inRightPlace)
                    {
                        correctTiles++;
                        
                    }
                }
            }

            if (correctTiles == 8)
            {
                Debug.Log("CheckPoint03");
                _isfinished = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            Debug.Log(correctTiles);
        }
        
    }

    public void Shuffle()
    {
        
        if (emptySpaceIndex != 8)
        {
            var tileOn8LastPos = tiles[8].targetPosition;
            tiles[8].targetPosition = emptySpace.position;
            emptySpace.position = tileOn8LastPos;
            tiles[emptySpaceIndex] = tiles[8];
            tiles = null;
            emptySpaceIndex = 8;
        }
        
        int invertion;
        do
        {
            for (int i = 0; i <= 8; i++)
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, tiles.Length - 2);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;
            }
            invertion = GetInversions();
            Debug.Log("Shuffled");
        } while (invertion % 2 != 0);
    }

    public int FindIndex(TileSlidePuzzle ts)
    {
        for (int i = 0;i < tiles.Length - 1;i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }
    
    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }
    
}
