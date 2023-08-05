using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDataMaterial : PointData
{
    [SerializeField] private static string[] materialTypeList;
    private int productionRate; 
    public string materialType;
    private static float occuranceModifier;

    static Dictionary<string,float> materialsWeight = new Dictionary<string, float>()
    {
            {"coal",33},
            {"iron",33},
            {"gold",33}
        };
    
    public PointDataMaterial(int prodRate, string matType)
    {
        productionRate = prodRate;
        materialType = matType;
    }
    public PointDataMaterial()
    {
        occuranceModifier = 1;

        materialTypeList = new string[3] {"coal", "iron", "gold"};
        productionRate = Random.Range(5, 30);
        materialType = materialTypeList[Random.Range(0, materialTypeList.Length)];

        for(int i =0;i<materialTypeList.Length;i++){
            if(materialTypeList[i]==materialType){
                materialsWeight[materialTypeList[i]]-=occuranceModifier;
            }
            else{
                materialsWeight[materialTypeList[i]]+=occuranceModifier/(materialTypeList.Length-1);
            }
        }
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