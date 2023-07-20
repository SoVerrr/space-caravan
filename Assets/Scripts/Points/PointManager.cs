using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] public SellPoint sellPoint;
    [SerializeField] public HubPoint hubPoint;
    [SerializeField] public MaterialPoint materialPoint;
    [SerializeField] public ProcessingPoint processingPoint;
    [SerializeField] SpaceGrid grid;
    [SerializeField] int spawnSpacing;
    public void GeneratePoint(Point planetPrefab)
    {
        int[] coords = FindSpawnSpot();
        if (coords == null || coords.Length == 0)
        {
            Debug.Log("No more suitable spawn points");
            return;
        }
        else
        {
            int x = coords[0];
            int y = coords[1];

            Collider[] hitColliders = new Collider[3];
            int colliders = Physics.OverlapSphereNonAlloc(new Vector3(x, 0, y), 0.3f, hitColliders);
            if (colliders > 0)
                Debug.Log("New point overlapping with another, wrong position");
            else
            {
                planetPrefab.InstantiatePoint(x, y);
                for (int xCoord = x - spawnSpacing; xCoord < x + spawnSpacing; xCoord++)
                {
                    for (int yCoord = y - spawnSpacing; yCoord < y + spawnSpacing; yCoord++)
                    {

                        if (xCoord >= 0 && xCoord < grid.DimensionX() && yCoord >= 0 && yCoord < grid.DimensionY())
                            grid.spawnStatus[xCoord, yCoord] = SpawnStatus.NotSpawnable;
                    }
                }
            }
        }
    }
    public void GeneratePlanet(Point planetPrefab, int x, int y)
    {
        Collider[] hitColliders = new Collider[3];
        int colliders = Physics.OverlapSphereNonAlloc(new Vector3(x, 0, y), 0.3f, hitColliders);
        if (colliders > 0)
            Debug.Log("New planet overlapping with another, wrong position");
        else
        {
            planetPrefab.InstantiatePoint(x, y);
            for (int xCoord = x - 4; xCoord < x + 4; xCoord++)
            {
                for (int yCoord = y - 4; yCoord < y + 4; yCoord++)
                {
                    if (xCoord > 0 && xCoord < grid.DimensionX() - 1 && yCoord > 0 && yCoord < grid.DimensionY() - 1)
                        grid.spawnStatus[xCoord, yCoord] = SpawnStatus.NotSpawnable;
                }
            }
        }
    }
    private int[] FindSpawnSpot(){
        List<int[]> spawnableCoords = new List<int[]>();
        for(int x = 0; x < grid.DimensionX(); x++)
        {
            for (int y = 0; y < grid.DimensionY(); y++)
            {
                if (grid.spawnStatus[x, y] == SpawnStatus.Spawnable)
                {
                    spawnableCoords.Add(new int[] { x, y});
                }
            }
        }
        if(spawnableCoords.Count > 0)
            return spawnableCoords[Random.Range(0, spawnableCoords.Count)];
        return null;

    }
    void Start()
    {
        GeneratePlanet(hubPoint, grid.DimensionX() / 2, grid.DimensionY() / 2);
        
    }
    void Update()
    {
        
    }
}
