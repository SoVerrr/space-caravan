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

    public Vector3[,] tileArray;
    public GridStatus[,] status;

    private void GenerateGrid()
    {
        int xSize = gridSizeX % 2 == 0 ? Mathf.FloorToInt(gridSizeX / 2) : Mathf.FloorToInt(gridSizeX / 2) + 1; //assign floored size / 2 if size is even and size / 2 + 1 if size is odd
        int ySize = gridSizeY % 2 == 0 ? Mathf.FloorToInt(gridSizeY / 2) : Mathf.FloorToInt(gridSizeY / 2) + 1; //assign floored size / 2 if size is even and size / 2 + 1 if size is odd
        for (int x = 0 - Mathf.CeilToInt(gridSizeX / 2); x < xSize; x++)
        {
            for(int y = 0 - Mathf.CeilToInt(gridSizeY / 2); y < ySize; y++)
            {
                tileArray[x + Mathf.CeilToInt(gridSizeX / 2), y + Mathf.CeilToInt(gridSizeY / 2)] = new Vector3(x, 0, y);
                status[x + Mathf.CeilToInt(gridSizeX / 2), y + Mathf.CeilToInt(gridSizeY / 2)] = GridStatus.Empty; //setting base status of a tile to empty 
                //status = new GridStatus[x + Mathf.CeilToInt(gridSizeX / 2), y + Mathf.CeilToInt(gridSizeY / 2)];

                if (debug)
                {
                    var spawnedTile = Instantiate(tile, new Vector3(x, -0.5f, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.transform.SetParent(gameObject.transform, true);
                }
            }
        }
    }
    public Vector3 AccessCell(int x, int y) { return tileArray[x, y]; }
    public GridStatus this[int x, int y]
    {
        get
        {
            return status[x + gridSizeX/2, y + gridSizeX / 2];
        }
        set
        {
            if(value == GridStatus.Route)
            {
                status[x + gridSizeX / 2, y + gridSizeX / 2] = GridStatus.Route;
            }
            
        }
         
    }
    // public void SetStatus(GridStatus type, int x, int y) { status[x, y] = type; }
    public int DimensionX()
    {
        int xSize = gridSizeX % 2 == 0 ? Mathf.FloorToInt(gridSizeX / 2) : Mathf.FloorToInt(gridSizeX / 2) + 1; //assign floored size / 2 if size is even and size / 2 + 1 if size is odd
        return xSize;
    }

    public int DimensionY() 
    {
        int ySize = gridSizeY % 2 == 0 ? Mathf.FloorToInt(gridSizeY / 2) : Mathf.FloorToInt(gridSizeY / 2) + 1; //assign floored size / 2 if size is even and size / 2 + 1 if size is odd
        return ySize; 
    }

    void Start()
    {
        tileArray = new Vector3[gridSizeX, gridSizeY];
        status = new GridStatus[gridSizeX, gridSizeY];
        GenerateGrid();
    }

    void Update()
    {
        
    }


}
