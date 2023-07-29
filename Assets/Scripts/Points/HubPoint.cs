using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPoint : Point
{
    public List<GameObject> hubPointList;
    public List<TradeRoute> routeList;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject truckPrefab;
    static public bool isUiEnabled = false;
    override public GameObject InstantiatePoint(int x, int y)
    {
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        hubPointList.Add(point);
        grid.status[x, y] = GridStatus.HubPoint;
        this.xCoordinate = x;
        this.yCoordinate = y;
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
    public void HubRightClick()
    {
        Debug.Log($"routelist count: {routeList.Count}");
        foreach(TradeRoute route in routeList)
        {
            var truck = Instantiate(truckPrefab, this.transform.position, Quaternion.identity);
            truck.GetComponent<TruckMovement>().SendOnRoute(route);
        }
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
