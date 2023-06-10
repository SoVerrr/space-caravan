using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;
public class ProcessingPoint : Point
{
    public static List<GameObject> processingPointsList;
    [SerializeField] private ProcessingResult[] ProcessingResults;
    private int processingResultIndex;
    [SerializeField] TextMeshProUGUI textElement;
    private string[] materialsNeeded;
    private int[] numberofMaterials;
    private string materialsPrint;

    override public void InstantiatePoint(int x, int y, PointData data)
    {

        processingResultIndex = Random.Range(0, ProcessingResults.Length);
        materialsNeeded = ProcessingResults[processingResultIndex].GetMaterialNeeded();
        numberofMaterials = ProcessingResults[processingResultIndex].GetNumberOfMaterialNeeded();
        materialsPrint = "Craft "+ProcessingResults[processingResultIndex].GetResultName().ToString()+"\n";
        for(int i=0; i<materialsNeeded.Length;i++){
            materialsPrint += materialsNeeded[i]+" "+numberofMaterials[i]+"\n";
        }
        textElement.text = materialsPrint;
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        processingPointsList.Add(point);


    }
    static ProcessingPoint()
    {
        processingPointsList = new List<GameObject>();
    }
    
}
