using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    private int width, height;
    private Dictionary<Vector3Int, StructureModel> temporaryRouteObject = new Dictionary<Vector3Int, StructureModel>();// Position of our structureModel, structure Model -> provide as with easy swap beacuse we can find postion and then swap model

    [SerializeField]
    SpaceGrid placementGrid;

    private void Start()
    {
        width = placementGrid.DimensionX();
        height = placementGrid.DimensionY();
    }

    internal GridStatus[] getNeighbourtStatus(Vector3Int position)
    {
        return placementGrid.GetAllAdjacentCellStatus(position.x, position.z);
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
        return placementGrid[position.x, position.z] == type;
    }

    public void PlaceTempStructure(Vector3Int position, GameObject structurePrefab, GridStatus type)
    {
        placementGrid[position.x, position.z] = type;

        StructureModel structureModel = CreateNewStrucutreModel(position, structurePrefab, type);

        temporaryRouteObject.Add(position, structureModel);
        
    }

    private StructureModel CreateNewStrucutreModel(Vector3Int position, GameObject structurePrefab, GridStatus type)
    {
        GameObject newStructure = new GameObject(type.ToString()); // set name 

        newStructure.transform.SetParent(transform);
        newStructure.transform.localPosition = position;

        var structureModel = newStructure.AddComponent<StructureModel>();
        structureModel.CreateStructure(structurePrefab); // Strucutre Model will Instantiate structure for as

        return structureModel;
    }

    public void ModifyStructureModel(Vector3Int position, GameObject newModel, Quaternion rotation)
    {
        if (temporaryRouteObject.ContainsKey(position)) // Check if position is true
            temporaryRouteObject[position].SwapStructure(newModel, rotation);
    }
}
