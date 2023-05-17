using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPlanet : Planet
{
    public static List<GameObject> materialPlanetList;

    private string materialType;
    private int productionRate;
    override public void InstantiatePlanet(int x, int y)
    {
        var planet = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        materialPlanetList.Add(planet);
    }
    public void InstantiateMaterialPlanet(int x, int y, int material, string production)
    {
        InstantiatePlanet(x, y);
        Init(material, production);
    }
    static MaterialPlanet()
    {
        materialPlanetList = new List<GameObject>();
    }

    private void Init(int material, string production)
    {
        productionRate = material;
        materialType = production;
    }
}
