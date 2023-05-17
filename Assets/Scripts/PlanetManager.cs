using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] private SellPlanet sellPlanet;
    [SerializeField] private StarterPlanet starterPlanet;
    [SerializeField] private MaterialPlanet materialPlanet;
    [SerializeField] private SpaceGrid spaceGrid;

    private void GenerateMaterialPlanet(MaterialPlanet planetPrefab, int x, int y, int production, string material)
    {
        Collider[] hitColliders = new Collider[3];
        int colliders = Physics.OverlapSphereNonAlloc(new Vector3(x, 0, y), 0.3f, hitColliders);
        if (colliders > 0)
            Debug.Log("New planet overlapping with another, wrong position");
        else
        {
            planetPrefab.InstantiatePlanet(x, y);
            
        }
    }



    void Start()
    {
        for(int x = 0; x < 5; x++)
        {
            for(int y = 0; y < 5; y++)
            {
                GenerateMaterialPlanet(materialPlanet, x, y, 2, "stone");
            }
        }
        Debug.Log(MaterialPlanet.materialPlanetList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
