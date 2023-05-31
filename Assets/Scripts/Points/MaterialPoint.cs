using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPoint : Point
{
    public static List<GameObject> materialPointList;

    private PointDataMaterial materialData;
    override public void InstantiatePoint(int x, int y, PointData data)
    {
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        materialPointList.Add(point);
        materialData = new PointDataMaterial();
        Debug.Log(materialData.GetMaterialType());
    }
    
    static MaterialPoint()
    {
        materialPointList = new List<GameObject>();
    }
}
