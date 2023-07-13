using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPoint : Point
{
    public List<GameObject> hubPointList;
    private List<TradeRoute> routeList;
    override public void InstantiatePoint(int x, int y)
    {
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        hubPointList.Add(point);
        grid.status[x, y] = GridStatus.HubPoint;
    }
    public override void Functionality(Inventory truckInventory)
    {
        Debug.Log("Collision");
    }
    public void CreateTradeRoute(params Point[] points)
    {
        routeList.Add(new TradeRoute(points));
    }
}
