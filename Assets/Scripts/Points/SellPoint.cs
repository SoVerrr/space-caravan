using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class SellPoint : Point
{ 
    public static List<GameObject> sellPointList;
    [SerializeField] SellPointData sellPointData;
    [SerializeField] Text textElement; 

    private string buyListPrint;

    private int priceMax;
    private int priceMin;
    private int price;

    List<string> names;
    private int[] sellingPrices;

    override public GameObject InstantiatePoint(int x, int y)
    { 
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        point.GetComponent<SellPoint>().SetValues(x, y);
        sellPointList.Add(point);
        grid.status[x, y] = GridStatus.SellPoint;
        return point;
    }

    void OnMouseOver()
    {
        textElement.text = buyListPrint;
    }

    void OnMouseExit()
    {
        textElement.text = "";
    }



    private void SetValues(int x, int y)
    {
        sellPointData.SetData();
        names = sellPointData.GetNames();
        sellingPrices = new int[names.Count];
        foreach (string name in names)
            Debug.Log(name);
        List<int> maxPrices = sellPointData.GetMaxPrices();
        List<int> minPrices = sellPointData.GetMinPrices();
        buyListPrint = "Sell:\n";
        for (int i = 0; i < names.Count; i++)
        {
            price = Random.Range(minPrices[i], maxPrices[i]);
            sellingPrices[i] = price;
            buyListPrint += names[i] + " " + price.ToString() + "g" + "\n";
            //Debug.Log(buyListPrint);
        }
        //Debug.Log(buyListPrint);
        //textElement.text = buyListPrint;
        this.xCoordinate = x;
        this.yCoordinate = y;
    }
    override public void Functionality(Inventory truckInventory)
    {
        for (int i = 0; i < names.Count; i++)
        {
            GameManager.Instance.score += truckInventory.getItemValue(names[i]) * sellingPrices[i];
            truckInventory.substractItem(names[i], truckInventory.getItemValue(names[i]));

        }
    }
    protected override void Awake()
    {
        base.Awake();
    }
    static SellPoint()
    {
        sellPointList = new List<GameObject>();
    }


}
