using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{

    [SerializeField] SpaceGrid grid;
    private bool isOnRoute = false;
    private List<Point> currentRoute;
    private List<Vector2Int> currentPath;
    private int currentPathCheckpoint = 0;
    private int currentRouteCheckpoint = 1;
    private int truckIndex;
    private HubPoint parentHub;
    private void Awake()
    {
        currentRoute = new List<Point>();
    }

    public void SendOnRoute(TradeRoute tradeRoute, HubPoint parent, int index)
    {
        parentHub = parent;
        truckIndex = index;
        currentRoute = tradeRoute.GetRoute();
        currentPath = GetPathToPoint(1);
        currentPathCheckpoint++;
        isOnRoute = true;
    }

    private List<Vector2Int> GetPathToPoint(int pointIndex)
    {
        try
        {
            List<Vector2Int> path = Pathfinding.AStarSearch(grid, currentRoute[pointIndex - 1].GetPointPosition(), currentRoute[pointIndex].GetPointPosition(), true);
            path.Reverse();
            return path;
        }
        catch
        {
            Debug.Log($"Index:{pointIndex} | PathCount:{currentRoute.Count} ");
            
            return null;
        }
    }

    private List<Vector2Int> GetPathToBeginning()
    {
        return Pathfinding.AStarSearch(grid, currentRoute[0].GetPointPosition(), currentRoute[currentRoute.Count - 1].GetPointPosition(), true);
    }

    private bool HasReachedCheckpoint(int index)
    {
        return transform.position == new Vector3(currentPath[index].x, 0, currentPath[index].y);
    }

    private bool HasFinishedRoute()
    {
        return currentRouteCheckpoint == currentRoute.Count + 1;
    }

    private void GoToCheckpoint(int index)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentPath[index].x, 0, currentPath[index].y), Time.deltaTime);
    }

    private bool NextCheckpoint()
    {
        if(currentPathCheckpoint < currentPath.Count - 1)
        {
            currentPathCheckpoint++;
            return true;
        }
        currentPathCheckpoint = 1;
        return false;
    }

    private void UpdatePath()
    {
        currentRouteCheckpoint++;
        if (HasFinishedRoute())
        {
            isOnRoute = false;
            parentHub.TruckBack(truckIndex);
            Destroy(gameObject);
        }

        if (currentRouteCheckpoint == currentRoute.Count)
        {
            currentPath = GetPathToBeginning();
        }
        else if(currentRouteCheckpoint < currentRoute.Count)
        {
            currentPath = GetPathToPoint(currentRouteCheckpoint);
        }

    }
    private void Update()
    {
        if (!isOnRoute)
        {
            return;
        }
        if (!HasReachedCheckpoint(currentPathCheckpoint))
        {
            GoToCheckpoint(currentPathCheckpoint);
        }
        else if (HasReachedCheckpoint(currentPathCheckpoint))
        {
            if (!NextCheckpoint())
            {
                UpdatePath();
            }
        }
            

    }
}
