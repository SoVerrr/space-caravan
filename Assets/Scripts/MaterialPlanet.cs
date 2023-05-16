using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPlanet : Planet
{
    public List<GameObject> materialPlanetList;
    override public void InstantiateObject(int x, int y)
    {
        var planet = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        materialPlanetList.Add(planet);
    }
}
