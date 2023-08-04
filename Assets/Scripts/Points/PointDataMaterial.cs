using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDataMaterial : PointData
{
    [SerializeField] private static string[] materialTypeList;
    private int productionRate; 
    public string materialType;



    private static int coalCounter;
    private static int ironCounter;
    private static int goldCounter;
    
    void Start(){
        Dictionary<string,int> materialsCounter = new Dictionary<string, int>(){
            {"coal",0},
            {"iron",0},
            {"gold",0}
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
        // if(coalCounter==0){
        //     materialType = "coal";
        // }
        // else if(ironCounter==0){
        //     materialType = "iron";
        // }
        // else if(goldCounter==0){
        //     materialType = "gold";
        // }
        // else{
        //     materialType = materialTypeList[Random.Range(0, materialTypeList.Length)];
        // }


        // if(materialType=="coal")
        // {
        //     coalCounter+=1;
        // }
        // else if(materialType=="iron")
        // {
        //     ironCounter+=1;
        // }
        // else if(materialType=="gold")
        // {
        //     goldCounter+=1;
        // }
        // else{
        //     Debug.Log("Wrong material type.");
        // }
    }

    public PointDataMaterial(string matType)
    {
        productionRate = Random.Range(5, 30);
        materialType = matType;
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