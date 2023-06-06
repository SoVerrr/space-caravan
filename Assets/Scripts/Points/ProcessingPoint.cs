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

    override public void InstantiatePoint(int x, int y)
    {

        processingResultIndex = Random.Range(0, ProcessingResults.Length);

        string[] materialsNeeded = ProcessingResults[processingResultIndex].GetMaterialNeeded();
        int[] numberofMaterials = ProcessingResults[processingResultIndex].GetNumberOfMaterialNeeded();
        string materialsPrint = ProcessingResults[processingResultIndex].GetResultName().ToString()+"\n";

        for(int i=0; i<materialsNeeded.Length;i++){
            materialsPrint += materialsNeeded[i]+" "+numberofMaterials[i]+"\n";
        }
        grid.status[x, y] = GridStatus.MaterialPoint;
        textElement.text = materialsPrint;
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        processingPointsList.Add(point);


    }
    static ProcessingPoint()
    {
        processingPointsList = new List<GameObject>();
    }
    
}
