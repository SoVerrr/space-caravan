using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] private SellPlanet sellPlanet;
    [SerializeField] private StarterPlanet starterPlanet;
    [SerializeField] private MaterialPlanet materialPlanet;
    [SerializeField] SpaceGrid grid;

    // private void GenerateMaterialPlanet(MaterialPlanet planetPrefab, int x, int y, int production, string material)
    // {
    //     Collider[] hitColliders = new Collider[3];
    //     int colliders = Physics.OverlapSphereNonAlloc(new Vector3(x, 0, y), 0.3f, hitColliders);
    //     if (colliders > 0)
    //         Debug.Log("New planet overlapping with another, wrong position");
    //     else
    //     {
    //         planetPrefab.InstantiatePlanet(x, y);
    //         grid[x, y] = GridStatus.MaterialPlanet;
    //     }
    // }
    private void GeneratePlanet(Planet planetPrefab, PlanetData data)
    {
        int[] coords = FindSpawnSpot();
        int x = coords[0];
        int y = coords[1];
        Collider[] hitColliders = new Collider[3];
        int colliders = Physics.OverlapSphereNonAlloc(new Vector3(x, 0, y), 0.3f, hitColliders);
        if (colliders > 0)
            Debug.Log("New planet overlapping with another, wrong position");
        else
        {
            planetPrefab.InstantiatePlanet(x, y, data);
            grid[x, y] = GridStatus.MaterialPlanet;
            for (int xCoord = x - 4; xCoord < x + 4; xCoord++)
            {
                for(int yCoord = y - 4; yCoord < y + 4; yCoord++)
                {
                    if(xCoord > 0 && xCoord < grid.DimensionX() - 1 && yCoord > 0 && yCoord < grid.DimensionY() - 1)
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
        return spawnableCoords[Random.Range(0, spawnableCoords.Count)];
        //Debug.Log("x: " + xCoord + "y: " + yCoord + "dimensions: " + grid.DimensionX() + " " + grid.DimensionY());

    }
    void Start()
    {
        PlanetDataMaterial dt = new PlanetDataMaterial(5, "stone");
        for (int x = 32; x < 37; x++)
        {
            for (int y = 32; y < 37; y++)
            {
                GeneratePlanet(materialPlanet, dt);
                //Debug.Log(spaceGrid[x, y] == GridStatus.MaterialPlanet);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
