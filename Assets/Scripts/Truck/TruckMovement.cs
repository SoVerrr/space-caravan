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

        List<Vector2Int> path = Pathfinding.AStarSearch(grid, currentRoute[pointIndex - 1].GetPointPosition(), currentRoute[pointIndex].GetPointPosition(), true);
        path.Reverse();
        if (path.Count > 0)
            return path;
        else
            return GetPathNoConnection();
    }

    private List<Vector2Int> GetPathToBeginning()
    {
        return Pathfinding.AStarSearch(grid, currentRoute[0].GetPointPosition(), new Vector2Int((int)transform.position.x, (int)transform.position.z), true);
    }
    private List<Vector2Int> GetPathNoConnection()
    {
        currentRoute.RemoveAt(currentRouteCheckpoint);
        if (currentRoute.Count == 1)
        {
            FinishRoute();
        }
        if (currentRoute.Count == currentRouteCheckpoint)
        {
            return Pathfinding.AStarSearch(grid, currentRoute[0].GetPointPosition(), new Vector2Int((int)transform.position.x, (int)transform.position.z), true);
        }
        else
        {
            return GetPathToPoint(currentRouteCheckpoint);
        }

    }
    private bool HasReachedCheckpoint(int index)
    {
        return transform.position == new Vector3(currentPath[index].x, transform.localPosition.y, currentPath[index].y);
    }

    private bool HasFinishedRoute()
    {
        return currentRouteCheckpoint == currentRoute.Count + 1;
    }

    private void GoToCheckpoint(int index)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentPath[index].x, transform.localPosition.y, currentPath[index].y), Time.deltaTime);
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
            FinishRoute();
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
    private void FinishRoute()
    {
        isOnRoute = false;
        parentHub.TruckBack(truckIndex);
        Destroy(gameObject);
    }
    public Vector3 GetCurrentTarget() 
    { 
        if(isOnRoute)
            return new Vector3(currentPath[currentPathCheckpoint].x, transform.localPosition.y, currentPath[currentPathCheckpoint].y);
        return Vector3.zero;
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
