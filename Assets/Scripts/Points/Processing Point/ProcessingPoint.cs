using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
public class ProcessingPoint : Point
{
    public static List<GameObject> processingPointsList;
    [SerializeField] private ProcessingResult[] ProcessingResults;
    private int processingResultIndex;
    [SerializeField] Text textElement; 
    private string[] materialsNeeded;
    private int[] numberofMaterials;
    private string materialsPrint;

    override public GameObject InstantiatePoint(int x, int y)
    {

        
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        point.GetComponent<ProcessingPoint>().SetValues(x, y);
        processingPointsList.Add(point);

        return point;
    }



    void OnMouseOver()
    {
        textElement.text = materialsPrint;
    }

    void OnMouseExit()
    {
        textElement.text = "";
    }


    private void SetValues(int x, int y)
    {
        processingResultIndex = Random.Range(0, ProcessingResults.Length);
        materialsNeeded = ProcessingResults[processingResultIndex].GetMaterialNeeded();
        numberofMaterials = ProcessingResults[processingResultIndex].GetNumberOfMaterialNeeded();
        materialsPrint = "Craft " + ProcessingResults[processingResultIndex].GetResultName().ToString() + "\n";
        for (int i = 0; i < materialsNeeded.Length; i++)
        {
            materialsPrint += materialsNeeded[i] + " " + numberofMaterials[i] + "\n";
        }
        grid.status[x, y] = GridStatus.MaterialPoint;
        //textElement.text = materialsPrint;
        this.xCoordinate = x;
        this.yCoordinate = y;
    }
    public override void Functionality(Inventory truckInventory)
    {
        int canProduce = 999;
        //count how many items can be produced by setting smallest quotient from materials available and materials needed
        for (int i = 0; i < materialsNeeded.Length; i++)
        {
            if (Mathf.Floor(truckInventory.getItemValue(materialsNeeded[i]) / numberofMaterials[i]) < canProduce)
            {
                canProduce = Mathf.FloorToInt(truckInventory.getItemValue(materialsNeeded[i]) / numberofMaterials[i]);
            }
        }
        //subtracting needed amount of materials from inventorty
        for (int i = 0; i < materialsNeeded.Length; i++)
        {
            truckInventory.substractItem(materialsNeeded[i], numberofMaterials[i] * canProduce);
        }
        //adding produced items to truck inventory
        truckInventory.addItem(ProcessingResults[processingResultIndex].GetResultName(), canProduce);
    }

    static ProcessingPoint()
    {
        processingPointsList = new List<GameObject>();
    }
    
}
