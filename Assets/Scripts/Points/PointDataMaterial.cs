using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDataMaterial : PointData
{
    [SerializeField] private static string[] materialTypeList;
    private int productionRate; 
    private string materialType;

    public PointDataMaterial(int prodRate, string matType)
    {
        productionRate = prodRate;
        materialType = matType;
    }
    public PointDataMaterial()
    {
        materialTypeList = new string[3] {"stone", "iron", "wood"};
        productionRate = Random.Range(5, 30);
        materialType = materialTypeList[Random.Range(0, materialTypeList.Length)];
    }

    public string GetMaterialType()
    {
        return materialType;
    }
}