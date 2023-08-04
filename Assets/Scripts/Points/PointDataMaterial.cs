using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDataMaterial : PointData
{
    [SerializeField] private static string[] materialTypeList;
    private int productionRate; 
    public string materialType;
  
    void Start(){
        Dictionary<string,int> materialsCounter = new Dictionary<string, int>(){
            {"coal",1},
            {"iron",1},
            {"gold",1}
        };
    }
    public PointDataMaterial(int prodRate, string matType)
    {
        productionRate = prodRate;
        materialType = matType;
    }
    public PointDataMaterial()
    {
        materialTypeList = new string[3] {"coal", "iron", "gold"};
        productionRate = Random.Range(5, 30);
        materialType = materialTypeList[Random.Range(0, materialTypeList.Length)];
    }

    public PointDataMaterial(string material)
    {
        productionRate = Random.Range(5, 30);
        materialType = material;
    }
    public string GetMaterialType()
    {
        return materialType;
    }
    public int GetProductionRate()
    {
        return productionRate;
    }
}