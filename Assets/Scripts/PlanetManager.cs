using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] private SellPlanet sellPlanetPrefab;
    [SerializeField] private StarterPlanet starterPlanetPrefab;
    [SerializeField] private MaterialPlanet materialPlanetPrefab;


    public List<GameObject> planetList;
    private void GeneratePlanet(Planet planetPrefab, int x, int y)
    {
        var planet = Instantiate(planetPrefab, new Vector3(x, 0, y), Quaternion.identity);

        planetList.Add(planet);    
    }

    void Start()
    {
        GeneratePlanet(sellPlanetPrefab, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
