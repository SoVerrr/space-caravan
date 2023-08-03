using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text UI

public enum GridStatus
{
    Empty,
    HubPoint,
    SellPoint,
    MaterialPoint,
    Route
}
public enum SpawnStatus
{
    Spawnable,
    NotSpawnable
}
public class SpaceGrid : MonoBehaviour
{
    [SerializeField] bool debug;
    [SerializeField] private int gridSizeX, gridSizeY;
    [SerializeField] private GameObject tile;
    [SerializeField] private Camera mainCamera;
    [SerializeField] Text textElement;
    public Vector3[,] tileArray;
    public GridStatus[,] status;
    public SpawnStatus[,] spawnStatus;
    [SerializeField] public int roadCounter;
    [SerializeField] public int roadLimit;
    [SerializeField] public int addRoad;   
    private int availableroads;  
    [SerializeField] private TimeManager timeManager;

    private int gridSizeXTemp, gridSizeYTemp;
    public Vector3[,] tileArrayTemp;
    public GridStatus[,] statusTemp;
    public SpawnStatus[,] spawnStatusTemp;



    private void GenerateGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                tileArray[x, y] = new Vector3(x, 0, y);
                status[x, y] = GridStatus.Empty; //setting base status of a tile to empty 
                spawnStatus[x, y] = SpawnStatus.Spawnable;
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

    // public int GetRoadLimit()
    // {
    //     return roadLimit;
    // }


    // public int ResizeGrid(){
    //     gridSizeXTemp +=1;
    //     gridSizeYTemp +=1;

    //     tileArrayTemp = new Vector3[gridSizeXTemp, gridSizeYTemp];
    //     statusTemp = new GridStatus[gridSizeXTemp, gridSizeYTemp];
    //     spawnStatusTemp = new SpawnStatus[gridSizeXTemp, gridSizeYTemp];
    //     // creating new Grid with new X and Y
    //     for (int x = 0; x < gridSizeXTemp; x++)
    //     {
    //         for(int y = 0; y < gridSizeYTemp; y++)
    //         {
    //             tileArrayTemp[x, y] = new Vector3(x, 0, y);
    //             statusTemp[x, y] = GridStatus.Empty;
    //             spawnStatusTemp[x, y] = SpawnStatus.Spawnable;
    //         }
    //     }

    //     // Debug.Log(tileArrayTemp);
    //     // return gridSizeXTemp;
    //     // Debug.Log(gridSizeX);
    //     // Debug.Log(gridSizeY);
    // }






    public Vector3 AccessCell(int x, int y) { return tileArray[x, y]; }

    public List<Vector2Int> GetAdjacentCells(Vector2Int cell, bool isAgent)
    {
        return GetWakableAdjacentCells(cell.x, cell.y, isAgent);
    }

    public float GetCostOfEnteringCell(Vector2Int cell)
    {
        return 1;
    }

    private List<Vector2Int> GetWakableAdjacentCells(int x, int y, bool isAgent)
    {
        List<Vector2Int> addjacentCells = GetAllAdjacentCell(x, y);

        for (int i = addjacentCells.Count - 1; i >= 0; i--)
        {
            if (IsCellWakable(status[addjacentCells[i].x, addjacentCells[i].y], isAgent) == false)
            {
                addjacentCells.RemoveAt(i);
            }
        }
        return addjacentCells;
    }

    private bool IsCellWakable(GridStatus gridStatus, bool aiAgent = false)
    {
        if (aiAgent)
        {

            return gridStatus != /*GridStatus.Route*/GridStatus.Empty;
        }

        return gridStatus == GridStatus.Empty || gridStatus == GridStatus.Route;
    }

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
            if (value == GridStatus.MaterialPoint)
            {
                status[x, y] = GridStatus.MaterialPoint;
            }
            if (value == GridStatus.Empty)
            {
                status[x, y] = GridStatus.Empty;
            }
            if (value == GridStatus.SellPoint)
            {
                status[x, y] = GridStatus.SellPoint;
            }
            if (value == GridStatus.HubPoint)
            {
                status[x, y] = GridStatus.HubPoint;
            }

        }
        
    }
    public Vector2Int GetGridSize()
    {
        return new Vector2Int(gridSizeX, gridSizeY);
    }
    public int GetRoadCounter(){
        roadCounter=0;
        for (int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                if(status[x,y]==GridStatus.Route){
                    roadCounter+=1;
                }
            }
        }
        availableroads = roadLimit-roadCounter;
        textElement.text = "Available roads: "+availableroads;
        return availableroads;
    }

    public int AddRoads()
    {
        roadLimit += addRoad;
        return roadLimit;

    }


    public List<Vector2Int> GetAllAdjacentCellStatusOfType(int x, int y, GridStatus type)
    {
        List<Vector2Int> adjacentCells = GetAllAdjacentCell(x, y);

        for (int i = adjacentCells.Count - 1; i >= 0; i--)
        {
            if (status[adjacentCells[i].x, adjacentCells[i].y] != type)
            {
                adjacentCells.RemoveAt(i);
            }
        }
        return adjacentCells;
    }

    private List<Vector2Int> GetAllAdjacentCell(int x, int y)
    {
        List<Vector2Int> adjacentCells = new List<Vector2Int>();
        

        if (x > 0)
        {
            adjacentCells.Add(new Vector2Int(x - 1, y));
        }
        if (x < gridSizeX - 1)
        {
            adjacentCells.Add(new Vector2Int(x + 1, y));
        }
        if (y > 0)
        {
            adjacentCells.Add(new Vector2Int(x , y  - 1));
        }
        if (y < gridSizeY - 1)
        {
            adjacentCells.Add(new Vector2Int(x, y + 1));
        }
        return adjacentCells;
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
        if (y < gridSizeY - 1)
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
        spawnStatus = new SpawnStatus[gridSizeX, gridSizeY];
        GenerateGrid();
    }

    void Update()
    {
        GetRoadCounter();
    }


}
