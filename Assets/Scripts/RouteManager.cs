using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    public Placement placement;

    public List<Vector3Int> tempPlacementPosition = new List<Vector3Int>();

    public GameObject structure;

    public void PlaceRoute(Vector3Int position)
    {
        if (placement.CheckIfTileInBound(position) == false)
            return;


        if (placement.CheckIfTileIsFree(position) == false)
            return;

        placement.PlaceTempStructure(position, structure, GridStatus.Route);
    }
}
