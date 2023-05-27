using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public static List<Vector2Int> AStarSearch(SpaceGrid grid, Vector2Int starPos, Vector2Int endPos, bool isAgent = false)
    {
        

        List<Vector2Int> path = new List<Vector2Int>();

        List<Vector2Int> posToCheck = new List<Vector2Int>();
        Dictionary<Vector2Int, float> costDictionary = new Dictionary<Vector2Int, float>();
        Dictionary<Vector2Int, float> priorityDictionary = new Dictionary<Vector2Int, float>();
        Dictionary<Vector2Int, Vector2Int> parentsDictionary = new Dictionary<Vector2Int, Vector2Int>();

        posToCheck.Add(starPos);
        priorityDictionary.Add(starPos, 0);
        costDictionary.Add(starPos, 0);
        parentsDictionary.Add(starPos, starPos);

        while(posToCheck.Count > 0)
        {
            Vector2Int current = GetClosesVertex(posToCheck, priorityDictionary);
            posToCheck.Remove(current);

            if (current.Equals(endPos))
            {
                path = GeneratePath(parentsDictionary, current);
                return path;
            }

            foreach (Vector2Int neighbour in grid.GetAdjacentCells(current, isAgent))
            {
                float newCost = costDictionary[current] + grid.GetCostOfEnteringCell(neighbour);

                if (!costDictionary.ContainsKey(neighbour) || newCost < costDictionary[neighbour])
                {
                    costDictionary[neighbour] = newCost;

                    float priority = newCost + ManhattanDistance(endPos, neighbour);

                    posToCheck.Add(neighbour);

                    priorityDictionary[neighbour] = priority;
                    parentsDictionary[neighbour] = current;
                }
            }
        }

        return path;
    }

    private static float ManhattanDistance(Vector2Int endPos, Vector2Int point)
    {
        return Math.Abs(endPos.x - point.x) + Math.Abs(endPos.y - point.y);
    }

    private static List<Vector2Int> GeneratePath(Dictionary<Vector2Int, Vector2Int> parentMap, Vector2Int endState)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int parent = endState;

        while (parent != null && parentMap.ContainsKey(parent))
        {
            path.Add(parent);
            parent = parentMap[parent];
        }

        return path;
    }

    private static Vector2Int GetClosesVertex(List<Vector2Int> list, Dictionary<Vector2Int, float> distanceMap)
    {
        Vector2Int candidate = list[0];

        foreach (Vector2Int vertex in list)
        {
            if (distanceMap[vertex] < distanceMap[candidate])
            {
                candidate = vertex;
            }
        }

        return candidate;
    }
}
