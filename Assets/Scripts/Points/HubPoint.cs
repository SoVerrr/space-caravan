using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPoint : Point
{
    public List<GameObject> hubPointList;
    public List<TradeRoute> routeList;
    [SerializeField] private GameObject UI;
    static public bool isUiEnabled = false;
    override public GameObject InstantiatePoint(int x, int y)
    {
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        hubPointList.Add(point);
        grid.status[x, y] = GridStatus.HubPoint;
        return point;
    }
    public override void Functionality(Inventory truckInventory)
    {
        Debug.Log("Collision");
    }
    public void CreateTradeRoute(params Point[] points)
    {
        routeList.Add(new TradeRoute(points));
    }

    public void HubPointClickEvent()
    {
        TradeRouteManager.Instance.SetParentHub(this);
        UI.SetActive(!isUiEnabled);
        isUiEnabled = !isUiEnabled;
    }
    private void Awake()
    {
        routeList = new List<TradeRoute>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            foreach (var item in routeList)
            {
                Debug.Log("---ROUTE---");
                item.PrintRoute();
            }
        }
    }
}
