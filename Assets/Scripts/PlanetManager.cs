using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] private SellPlanet sellPlanet;
    [SerializeField] private StarterPlanet starterPlanet;
    [SerializeField] private MaterialPlanet materialPlanet;


    private void GeneratePlanet(Planet planetPrefab, int x, int y)
    {
        Collider[] hitColliders = new Collider[3];
        int colliders = Physics.OverlapSphereNonAlloc(new Vector3(x, 0, y), 0.3f, hitColliders);
        if (colliders > 0)
            Debug.Log("New planet overlapping with another, wrong position");
        else
            planetPrefab.InstantiateObject(x, y);

    }

    void Start()
    {
        for(int x = 0; x < 5; x++)
        {
            for(int y = 0; y < 5; y++)
            {
                GeneratePlanet(materialPlanet, x, y);
            }
        }
        Debug.Log(materialPlanet.materialPlanetList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
