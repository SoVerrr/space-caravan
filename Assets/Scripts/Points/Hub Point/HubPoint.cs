using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPoint : Point
{
    public List<GameObject> hubPointList;
    public List<TradeRoute> routeList;
    [SerializeField] public GameObject UI;
    [SerializeField] private GameObject truckPrefab;
    [SerializeField] private PointManager pointManager;   

    static public bool isUiEnabled = false;
    public List<bool> isTruckOnRoute;
    override public GameObject InstantiatePoint(int x, int y)
    {
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        point.GetComponent<HubPoint>().SetValues(x, y);
        hubPointList.Add(point);
        grid.status[x, y] = GridStatus.HubPoint;
        pointManager.hubPointCounter+=1;
        return point;
    }
    private void SetValues(int x, int y)
    {
        this.xCoordinate = x;
        this.yCoordinate = y;
    }
    public override void Functionality(Inventory truckInventory)
    {
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
    protected override void Awake()
    {
        base.Awake();
        routeList = new List<TradeRoute>();
    }
    public void TruckBack(int index)
    {
        if (routeList.Count == 0)
            return;

        if (index < routeList.Count)
            isTruckOnRoute[index] = false;
    }
    protected override void Update()
    {
        base.Update();
        if (isTruckOnRoute.Count < routeList.Count)
        {
            isTruckOnRoute.Add(false);
        }
        if (isTruckOnRoute.Count > routeList.Count)
        {
            isTruckOnRoute.RemoveAt(0);
        }
        for (int i = 0; i < isTruckOnRoute.Count; i++)
        {
            if (!isTruckOnRoute[i])
            {

                var truck = Instantiate(truckPrefab, new Vector3(transform.position.x, truckPrefab.transform.localPosition.y, transform.position.z), Quaternion.identity);
                truck.GetComponent<TruckMovement>().SendOnRoute(routeList[i], this, i);
                isTruckOnRoute[i] = true;
            }
        }

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
