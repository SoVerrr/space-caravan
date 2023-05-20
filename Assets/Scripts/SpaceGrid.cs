using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GridStatus
{
    Empty,
    StarterPlanet,
    SellPlanet,
    MaterialPlanet,
    Route
}
public class SpaceGrid : MonoBehaviour
{
    [SerializeField] bool debug;
    [SerializeField] private int gridSizeX, gridSizeY;
    [SerializeField] private GameObject tile;
    [SerializeField] private Camera mainCamera;

    public Vector3[,] tileArray;
    public GridStatus[,] status;

    private void GenerateGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                tileArray[x, y] = new Vector3(x, 0, y);
                status[x, y] = GridStatus.Empty; //setting base status of a tile to empty 
                if (debug)
                {
                    var spawnedTile = Instantiate(tile, new Vector3(x, -0.5f, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.transform.SetParent(gameObject.transform, true);
                }
            }
        }
        mainCamera.transform.position = new Vector3(gridSizeX/2, 14, gridSizeY/2);
        
    }
    public Vector3 AccessCell(int x, int y) { return tileArray[x, y]; }
    public GridStatus this[int x, int y]
    {
        get
        {
            return status[x, y];
        }
        set
        {
            if(value == GridStatus.Route)
            {
                status[x, y] = GridStatus.Route;
            }
            if (value == GridStatus.MaterialPlanet)
            {
                status[x, y] = GridStatus.MaterialPlanet;
            }

        }
         
    }
    
    public GridStatus[] GetAllAdjacentCellStatus(int x, int y) // Returns array [Left neighbour, Top neighbour, Right neighbour, Down neighbour]
    {
        GridStatus[] neighbours = { GridStatus.Empty, GridStatus.Empty, GridStatus.Empty, GridStatus.Empty };

        if(x > 0)
        {
            neighbours[0] = status[x - 1, y];
        }
        if (x < gridSizeX - 1)
        {
            neighbours[2] = status[x + 1, y];
        }
        if (y > 0)
        {
            neighbours[3] = status[x, y - 1];
        }
        if (x < gridSizeY - 1)
        {
            neighbours[1] = status[x, y + 1];
        }

        return neighbours;
    }

    public int DimensionX()
    {
        return gridSizeX;
    }

    public int DimensionY() 
    {
        return gridSizeY; 
    }

    void Awake()
    {
        tileArray = new Vector3[gridSizeX, gridSizeY];
        status = new GridStatus[gridSizeX, gridSizeY];
        GenerateGrid();
    }

    void Update()
    {
        
    }


}
