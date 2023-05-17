using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    private int width, height;

    [SerializeField]
    SpaceGrid placementGrid;

    private void Start()
    {
        width = placementGrid.DimensionX();
        height = placementGrid.DimensionY();
    }

    internal bool CheckIfTileInBound(Vector3Int position)
    {
        if(position.x >= -(width/2) && position.x < width && position.z >= -(height / 2) && position.z < height) 
        {
            return true;
        }
        return false;
    }

    internal bool CheckIfTileIsFree(Vector3Int position)
    {
        return CheckIfPositionStatus(position, GridStatus.Empty);
    }

    private bool CheckIfPositionStatus(Vector3Int position, GridStatus type)
    {
        Debug.Log("Halo");
        return placementGrid[position.x, position.z] == type;
    }

    public void PlaceTempStructure(Vector3Int position, GameObject structure, GridStatus type)
    {
        placementGrid[position.x, position.z] = type;
        GameObject newStructure = Instantiate(structure, position, Quaternion.identity);
        
    }
}
