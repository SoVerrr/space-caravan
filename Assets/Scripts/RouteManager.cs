using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    public Placement placement;

    public List<Vector3Int> tempPlacementPosition = new List<Vector3Int>();
    public List<Vector3Int> routePositionToRecheck = new List<Vector3Int>(); // List for neighbours if they need to be changed

    public RouteFixer routeFixer; // has access to all routes

    private Vector3Int startPos;
    private bool placmentMode = false;

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

        if (placmentMode == false)
        {
            tempPlacementPosition.Clear(); // Clear before using new prefab
            routePositionToRecheck.Clear(); // Clear position to recheck prevents from rechecking already checked position

            placmentMode = true;
            startPos = position;

            tempPlacementPosition.Add(position);
            Debug.Log("eeeeee");
            placement.PlaceTempStructure(position, routeFixer.routeStraight, GridStatus.Route);

            
        }
        else
        {
            placement.RemoveAllTemporaryStructure();
            
            tempPlacementPosition.Clear();
            routePositionToRecheck.Clear();

            tempPlacementPosition = placement.GetPathBetween(startPos, position);

            foreach (var tempPos in tempPlacementPosition)
            {
                Debug.Log("IFFFFF");
                if (placement.CheckIfTileIsFree(tempPos) == false)
                {
                    Debug.Log(placement.placementGrid[position.x, position.z]);
                    continue;
                }
                
                placement.PlaceTempStructure(tempPos, routeFixer.routeStraight, GridStatus.Route);
            }
        }

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
                if (routePositionToRecheck.Contains(routeposition) == false)
                {
                    routePositionToRecheck.Add(routeposition);
                }
            }
        }

        foreach (var positionToFix in routePositionToRecheck)
        {
            routeFixer.FixRouteAtPosition(placement, positionToFix);
        }
    }

    public void FinishPlacingRoute()
    {
        placmentMode = false;
        placement.AddtemporaryStructuresToStructureDict();

        tempPlacementPosition.Clear();

        startPos = Vector3Int.zero;

    }
}
