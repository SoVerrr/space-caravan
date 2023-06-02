using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MaterialPoint : Point
{
    public static List<GameObject> materialPointList;
    [SerializeField] TextMeshProUGUI textElement;
    private PointDataMaterial materialData;
    override public void InstantiatePoint(int x, int y, PointData data)
    {
        // var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        // materialPointList.Add(point);
        materialData = new PointDataMaterial();
        //prodRate = materialData.GetProductionRate();
        Debug.Log("coords: " + x + " " + y + " type: " + materialData.GetProductionRate());
        textElement.text = materialData.GetProductionRate().ToString();
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        materialPointList.Add(point);

    }

    
    static MaterialPoint()
    {
        materialPointList = new List<GameObject>();
    }
}
