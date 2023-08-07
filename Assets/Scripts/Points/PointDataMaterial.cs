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
        weightsList.Add(1);
        weightsList.Add(sum);
        
        for(int i=1;i<materialTypeList.Length;i++){
            sum+=materialsWeight[materialTypeList[i]];
            weightsList.Add(sum);

        }
        //Debug.Log("coal:"+weightsList[0]+"-"+weightsList[1]+"     iron:"+weightsList[1]+"-"+weightsList[2]+"      gold:"+weightsList[2]+"-"+weightsList[3]);
 

        randomNumber = Random.Range(1,weightsList[materialTypeList.Length-1]);
        //Debug.Log("Random number:"+randomNumber);


        for(int i =0; i<weightsList.Count-1;i++){
            if(weightsList[i]<randomNumber && randomNumber<=weightsList[i+1]){
                //Debug.Log(materialTypeList[i]);
                materialType = materialTypeList[i];
            }
        }

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