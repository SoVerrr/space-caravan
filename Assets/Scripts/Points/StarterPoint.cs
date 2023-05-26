using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterPoint : Point
{
    public List<GameObject> starterPlanetList;
    override public void InstantiatePoint(int x, int y, PointData data)
    {
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        starterPlanetList.Add(point);
    }
}
