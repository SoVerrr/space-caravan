using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDataMaterial : PointData
{
    [SerializeField] private static string[] materialTypeList;
    private int productionRate; 
    public string materialType;
    private float randomNumber;
    private static float sum;

    static Dictionary<string,float> materialsWeight = new Dictionary<string, float>()
    {
            {"coal",33},
            {"iron",33},
            {"gold",33}
        };

   // static List<string,float,float> generatingWeight = new List<string,float,float>();


    List<float> weightsList = new List<float>();
    
    public PointDataMaterial(int prodRate, string matType)
    {
        productionRate = prodRate;
        materialType = matType;
    }
    public PointDataMaterial()
    {

        materialTypeList = new string[3] {"coal", "iron", "gold"};
        productionRate = Random.Range(5, 30);
        sum = 0;
        sum = materialsWeight[materialTypeList[0]];
        weightsList.Add(sum);
        
        for(int i=1;i<materialTypeList.Length;i++){
            sum+=materialsWeight[materialTypeList[i]];
            weightsList.Add(sum);

        }


        
        randomNumber = Random.Range(1,weightsList[materialTypeList.Length-1]);
        Debug.Log(randomNumber);

        materialType = materialTypeList[Random.Range(0, materialTypeList.Length)];

        for(int i =0;i<materialTypeList.Length;i++){
            if(materialTypeList[i]==materialType){
                materialsWeight[materialTypeList[i]]-=GameManager.Instance.occuranceModifier;
            }
            else{
                materialsWeight[materialTypeList[i]]+=GameManager.Instance.occuranceModifier/(materialTypeList.Length-1);
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