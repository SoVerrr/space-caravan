using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int gridSizeX, gridSizeY;
    [SerializeField] private GameObject tile;

    public Vector3[,] tileArray;

    private void GenerateGrid()
    {
        int xSize = gridSizeX % 2 == 0 ? Mathf.FloorToInt(gridSizeX / 2) : Mathf.FloorToInt(gridSizeX / 2) + 1; //assign floored size / 2 if size is even and size / 2 + 1 if size is odd
        int ySize = gridSizeY % 2 == 0 ? Mathf.FloorToInt(gridSizeY / 2) : Mathf.FloorToInt(gridSizeY / 2) + 1; //assign floored size / 2 if size is even and size / 2 + 1 if size is odd
        for (int x = 0 - Mathf.CeilToInt(gridSizeX / 2); x < xSize; x++)
        {
            for(int y = 0 - Mathf.CeilToInt(gridSizeY / 2); y < ySize; y++)
            {
                tileArray[x + Mathf.CeilToInt(gridSizeX / 2), y + Mathf.CeilToInt(gridSizeY / 2)] = new Vector3((float)x, 0, (float)x);
                var spawnedTile = Instantiate(tile, new Vector3(x, -0.5f, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
            }
        }
    }
    public Vector3 AccessCell(int x, int y) { return tileArray[x, y]; }

    void Start()
    {
        tileArray = new Vector3[gridSizeX, gridSizeY];
        GenerateGrid();
    }

    void Update()
    {
        
    }


}
