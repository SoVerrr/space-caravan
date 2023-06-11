using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MaterialPoint : Point
{
    public static List<GameObject> materialPointList;
    [SerializeField] TextMeshProUGUI textElement;
    private PointDataMaterial materialData;
    override public void InstantiatePoint(int x, int y)
    {
        materialData = new PointDataMaterial();
        //Debug.Log("coords: " + x + " " + y + " type: " + materialData.GetProductionRate());
        textElement.text = "Collect\n" +materialData.GetProductionRate().ToString()+" "+materialData.GetMaterialType().ToString()+"\n";
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        grid.status[x, y] = GridStatus.MaterialPoint;
        materialPointList.Add(point);
    }
    public override void Functionality(Inventory truckInventory)
    {
        truckInventory.addItem(materialData.GetMaterialType(), materialData.GetProductionRate());
    }
    static MaterialPoint()
    {
        materialPointList = new List<GameObject>();
    }
}
