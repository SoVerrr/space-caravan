using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MaterialPoint : Point
{
    public static List<GameObject> materialPointList;
    [SerializeField] Text textElement;
    private PointDataMaterial materialData;
    [SerializeField] private PointManager pointManager;
    override public GameObject InstantiatePoint(int x, int y)
    {
        //Debug.Log("coords: " + x + " " + y + " type: " + materialData.GetProductionRate());
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        point.GetComponent<MaterialPoint>().SetValues(x, y);
        grid.status[x, y] = GridStatus.MaterialPoint;
        materialPointList.Add(point);
        pointManager.materialPointCounter+=1;
        return point;
    }

    public GameObject InstantiateMaterialPoint(int x, int y, string material)
    {
        //Debug.Log("coords: " + x + " " + y + " type: " + materialData.GetProductionRate());
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        point.GetComponent<MaterialPoint>().SetValues(x, y, material);
        grid.status[x, y] = GridStatus.MaterialPoint;
        materialPointList.Add(point);
        pointManager.materialPointCounter+=1;
        return point;
    }

    void OnMouseOver()
    {
        textElement.text = "Collect\n" + materialData.GetProductionRate().ToString() + " " + materialData.GetMaterialType().ToString() + "\n";
    }
    void OnMouseExit()
    {
        textElement.text = "";
    }
    private void SetValues(int x, int y)
    {
        materialData = new PointDataMaterial();
        this.xCoordinate = x;
        this.yCoordinate = y;
    }
    private void SetValues(int x, int y, string material)
    {
        materialData = new PointDataMaterial(material);
        this.xCoordinate = x;
        this.yCoordinate = y;
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
