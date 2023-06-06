using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProcessingResult : ScriptableObject
{
    [SerializeField] string resultName;
    [SerializeField] string[] materialsNeeded;
    [SerializeField] int[] numberOfMaterialsNeeded;

    public string GetResultName()
    {       
        return resultName;
    }
    public string[] GetMaterialNeeded()
    {
        return materialsNeeded;
    }
    public int[] GetNumberOfMaterialNeeded()
    {
        return numberOfMaterialsNeeded;
    }
}