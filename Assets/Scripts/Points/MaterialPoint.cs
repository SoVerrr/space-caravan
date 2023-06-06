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
        textElement.text = materialData.GetMaterialType().ToString() + "\n" + materialData.GetProductionRate().ToString();
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        grid.status[x, y] = GridStatus.MaterialPoint;
        materialPointList.Add(point);
    }

    static MaterialPoint()
    {
        materialPointList = new List<GameObject>();
    }
}
