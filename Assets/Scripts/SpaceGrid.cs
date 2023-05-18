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
    // public void SetStatus(GridStatus type, int x, int y) { status[x, y] = type; }
    public int DimensionX()
    {
        return gridSizeX;
    }

    public int DimensionY() 
    {
        return gridSizeY; 
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
