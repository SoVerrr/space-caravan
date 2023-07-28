using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private List<Node> openCells;
    private HashSet<Node> closedCells;
    public List<Vector2Int> finalPath;
    private Vector2Int targetCell;
    private Vector2Int startCell;
    [SerializeField] SpaceGrid grid;
    class Node
    {
        public Node parent;
        public Vector2Int position;
        public int costF, costH, costG;
        public Node(Vector2Int currentCell, Node parentCell, int costF, int costH, int costG)
        {
            parent = parentCell;
            position = currentCell;
            this.costF = costF;
            this.costG = costG;
            this.costH = costH;
            
        }
    }
    private Node startNode;
    int GetDistance(Vector2Int currentPosition, Vector2Int destination)
    {
        int distX = Mathf.Abs(currentPosition.x - destination.x);
        int distZ = Mathf.Abs(currentPosition.y - destination.y);
        if (distZ > distX)
            return 14 * distZ + 10 * (distX - distZ);
        return 14 * distX + 10 * (distZ - distX);
    }
    public int CostH(Vector2Int currentPosition)
    {
        return GetDistance(currentPosition, targetCell);
    }
    int CostG(Vector2Int currentPosition)
    {
        return GetDistance(currentPosition, startCell);
    }
    int CostF(Vector2Int currentPosition)
    {
        return CostH(currentPosition) + CostG(currentPosition);
    }
    List<Vector2Int> RetracePath(Node startNode, Node finishNode)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Node currentNode = startNode;
        while(currentNode.position != finishNode.position)
        {
            path.Add(currentNode.position);
            currentNode = currentNode.parent;
        }
        return path;
    }
    private void FindPath(Vector2Int startPosition, Vector2Int endPosition)
    {
        openCells = new List<Node>();
        closedCells = new HashSet<Node>();
        startNode = new Node(startPosition, null, CostF(startPosition), CostH(startPosition), CostG(startPosition));
        openCells.Add(startNode);
        while(openCells.Count > 0)
        {
            Node currentCell = openCells[0];
            foreach (var cell in openCells)
            {
                if (currentCell.costF < cell.costF || currentCell.costF == cell.costF && currentCell.costH > cell.costH)
                    currentCell = cell;
            }
            openCells.Remove(currentCell);
            closedCells.Add(currentCell);
            if (currentCell.position == endPosition)
            {
                finalPath = RetracePath(currentCell, startNode);
                return;
            }
            List<Vector2Int> adjacent = grid.GetAdjacentCells(currentCell.position, false);
            foreach (var item in adjacent)
            {
                Debug.Log("aaaaaa");
                Node neighour = new Node(item, currentCell, CostF(item), CostH(item), CostG(item));
                if (closedCells.Contains(neighour)) continue;
                int newMovementCostToNeighbour = currentCell.costG + GetDistance(currentCell.position, neighour.position);
                if (newMovementCostToNeighbour < neighour.costG || openCells.Contains(neighour))
                {
                    neighour.costG = newMovementCostToNeighbour;
                    if (!openCells.Contains(neighour))
                        openCells.Add(neighour);
                }


            }
        }
    }

    public void SendTruck(Vector2Int startingPoint, Vector2Int endingPoint)
    {
        FindPath(startingPoint, endingPoint);
        foreach (var item in finalPath)
        {
            while(transform.position.x != item.x && transform.position.z != item.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(item.x, transform.position.y, item.y), 5 * Time.deltaTime);
            }
        }
    }
    public void SendOnRoute(TradeRoute route)
    {
        List<Point> tradeRoute = route.GetRoute();
        for(int i = 0; i < tradeRoute.Count; i++)
        {
            if (i < tradeRoute.Count - 1)
                SendTruck(tradeRoute[i].GetPointPosition(), tradeRoute[i + 1].GetPointPosition());
            else
                SendTruck(tradeRoute[i].GetPointPosition(), tradeRoute[0].GetPointPosition());
        }
    }
}
