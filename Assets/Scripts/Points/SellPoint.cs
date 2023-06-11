using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;
public class SellPoint : Point
{
    public static List<GameObject> sellPointList;
    [SerializeField] private ProcessingResult[] SellingResults;
    [SerializeField] TextMeshProUGUI textElement;

    private string buyListPrint;

    private int priceMax;
    private int priceMin;
    private int price;

    override public void InstantiatePoint(int x, int y, PointData data)
    {   
        buyListPrint = "Sell:\n";
        for(int i=0; i<SellingResults.Length;i++){
            priceMax = SellingResults[i].GetPriceMax();
            priceMin = SellingResults[i].GetPriceMin();
            price = Random.Range(priceMin,priceMax);
            buyListPrint += SellingResults[i].GetResultName().ToString()+" "+price.ToString()+"g"+"\n";
        }
        textElement.text = buyListPrint;
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        sellPointList.Add(point);
        grid.status[x, y] = GridStatus.SellPoint;
    }

    static SellPoint()
    {
        sellPointList = new List<GameObject>();
    }


}
