using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MaterialPoint : Point
{
    public static List<GameObject> materialPointList;
    [SerializeField] TextMeshProUGUI textElement;
    private PointDataMaterial materialData;
    override public GameObject InstantiatePoint(int x, int y)
    {
        //Debug.Log("coords: " + x + " " + y + " type: " + materialData.GetProductionRate());
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        point.GetComponent<MaterialPoint>().SetValues(x, y);
        grid.status[x, y] = GridStatus.MaterialPoint;
        materialPointList.Add(point);
        
        return point;
    }
    private void SetValues(int x, int y)
    {
        materialData = new PointDataMaterial();
        this.xCoordinate = x;
        this.yCoordinate = y;
        textElement.text = "Collect\n" + materialData.GetProductionRate().ToString() + " " + materialData.GetMaterialType().ToString() + "\n";
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
