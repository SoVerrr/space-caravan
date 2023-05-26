using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPlanet : Planet
{
    public static List<GameObject> materialPlanetList;

    private string materialType;
    private int productionRate;
    private PlanetDataMaterial materialData;
    override public void InstantiatePlanet(int x, int y, PlanetData data)
    {
        var planet = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        materialPlanetList.Add(planet);

        materialData = (PlanetDataMaterial)data;        


    }
    
    static MaterialPlanet()
    {
        materialPlanetList = new List<GameObject>();
    }
}
