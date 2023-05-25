using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPlanet : Planet
{
    public List<GameObject> sellPlanetList;
    override public void InstantiatePlanet(int x, int y, PlanetData data)
    {
        var planet = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        sellPlanetList.Add(planet);
    }
}
