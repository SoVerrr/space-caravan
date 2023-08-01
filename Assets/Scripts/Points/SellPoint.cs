using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class SellPoint : Point
{
    public static List<GameObject> sellPointList;
    [SerializeField] private ProcessingResult[] SellingResults;
    private int[] sellingPrices;
    [SerializeField] TextMeshProUGUI textElement;

    private string buyListPrint;

    private int priceMax;
    private int priceMin;
    private int price;

    override public GameObject InstantiatePoint(int x, int y)
    { 
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        point.GetComponent<SellPoint>().SetValues(x, y);
        sellPointList.Add(point);
        grid.status[x, y] = GridStatus.SellPoint;
        return point;
    }
    private void SetValues(int x, int y)
    {
        buyListPrint = "Sell:\n";
        for (int i = 0; i < SellingResults.Length; i++)
        {
            priceMax = SellingResults[i].GetPriceMax();
            priceMin = SellingResults[i].GetPriceMin();
            price = Random.Range(priceMin, priceMax);
            sellingPrices[i] = price;
            buyListPrint += SellingResults[i].GetResultName().ToString() + " " + price.ToString() + "g" + "\n";
        }
        textElement.text = buyListPrint;
        this.xCoordinate = x;
        this.yCoordinate = y;
    }
    override public void Functionality(Inventory truckInventory)
    {
        for (int i = 0; i < SellingResults.Length; i++)
        {
            GameManager.Instance.score += truckInventory.getItemValue(SellingResults[i].GetResultName()) * sellingPrices[i];
            truckInventory.substractItem(SellingResults[i].GetResultName(), truckInventory.getItemValue(SellingResults[i].GetResultName()));

        }
        //TODO: add items/money for selling
    }
    protected override void Awake()
    {
        base.Awake();
        sellingPrices = new int[SellingResults.Length];
    }
    static SellPoint()
    {
        sellPointList = new List<GameObject>();
    }


}
