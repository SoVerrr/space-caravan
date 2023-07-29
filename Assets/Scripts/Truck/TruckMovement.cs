using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{

    [SerializeField] SpaceGrid grid;
    public void SendTruck(Point startingPoint, Point endPoint)
    {
        /*Vector2Int startPos = startingPoint.GetPointPosition();
        Vector2Int endPos = endPoint.GetPointPosition();
        Debug.Log($"Startpos:{startPos} | endpos: {endPos}");
        List<Vector2Int> path = Pathfinding.AStarSearch(grid, startPos, endPos, true);
        path.Reverse();*/
    }
    IEnumerator MoveTruckToPosition(List<Point> route)
    {
        for (int i = 0; i < route.Count; i++)
        {
            List<Vector2Int> path = new List<Vector2Int>();
            if (i < route.Count - 1)
            {
                Vector2Int startPos = route[i].GetPointPosition();
                Vector2Int endPos = route[i + 1].GetPointPosition();
                Debug.Log($"Startpos:{startPos} | endpos: {endPos}");
                path = Pathfinding.AStarSearch(grid, startPos, endPos, true);
            }
            else
            {
                Vector2Int startPos = route[i].GetPointPosition();
                Vector2Int endPos = route[0].GetPointPosition();
                Debug.Log($"Startpos:{startPos} | endpos: {endPos}");
                path = Pathfinding.AStarSearch(grid, startPos, endPos, true);
            }
            path.Reverse();

            foreach (Vector2Int pathItem in path)
            {
                Vector3 target = new Vector3(pathItem.x, 0, pathItem.y);
                while (transform.position != target)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
                    yield return null;
                }
            }
        }
        

    }
    public void SendOnRoute(TradeRoute tradeRoute)
    {
        List<Point> route = tradeRoute.GetRoute();
        StartCoroutine(MoveTruckToPosition(route));
        /*for (int i = 0; i < route.Count - 1; i++)
        {
            SendTruck(route[i], route[i + 1]);
        }*/
    }
}
