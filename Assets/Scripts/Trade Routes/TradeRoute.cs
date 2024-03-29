using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeRoute
{
    private List<Point> tradeRoute;
    private string routeName;
    // Start is called before the first frame update
    public TradeRoute(params Point[] points)
    {
        tradeRoute = new List<Point>();
        foreach (var item in points)
        {
            tradeRoute.Add(item);
        }
    }
    public void AddToRoute(Point point)
    {
        //TODO: Function that checks if 2 points are connected via road
        tradeRoute.Add(point);
    }
    public int RemoveFromRoute(Point point)
    {
        if (tradeRoute.Contains(point))
        {
            tradeRoute.Remove(point);
            return 1;
        }
        else
        {
            return 0;
        }

    }
    public List<Point> GetRoute()
    {
        return tradeRoute;
    }
    public void PrintRoute()
    {
        foreach (var item in tradeRoute)
            Debug.Log(item);
    }
    public string RouteName
    {
        get { return routeName; }
        set { routeName = value; }
    }
}
