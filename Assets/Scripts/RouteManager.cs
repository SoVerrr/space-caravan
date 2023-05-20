using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    public Placement placement;

    public List<Vector3Int> tempPlacementPosition = new List<Vector3Int>();
    public List<Vector3Int> routePositionToRecheck = new List<Vector3Int>(); // List for neighbours if they need to be changed

    public GameObject structure;

    public RouteFixer routeFixer;

    private void Start()
    {
        routeFixer = GetComponent<RouteFixer>();
    }

    public void PlaceRoute(Vector3Int position)
    {
        if (placement.CheckIfTileInBound(position) == false)
            return;


        if (placement.CheckIfTileIsFree(position) == false)
            return;

        tempPlacementPosition.Clear(); // Clear before using new prefab
        tempPlacementPosition.Add(position);


        placement.PlaceTempStructure(position, structure, GridStatus.Route);

        FixRoutePrefab();
    }

    private void FixRoutePrefab()
    {
        foreach (var routePosition in tempPlacementPosition)
        {
            routeFixer.FixRouteAtPosition(placement, routePosition);
            var neighbours = placement.getNeighbourtOfStatusFor(routePosition, GridStatus.Route);

            foreach (var routeposition in neighbours)
            {
                routePositionToRecheck.Add(routeposition);
            }
        }

        foreach (var positionToFix in routePositionToRecheck)
        {
            routeFixer.FixRouteAtPosition(placement, positionToFix);
        }
    }
}
