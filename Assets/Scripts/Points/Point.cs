using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Point : MonoBehaviour
{
    private int xCoordinate, yCoordinate;
    [SerializeField] protected SpaceGrid grid;
    abstract public GameObject InstantiatePoint(int x, int y);
    abstract public void Functionality(Inventory truckInventory);

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Vehicle")
        {
            Functionality(collision.gameObject.GetComponent<Inventory>());
        }
    }

    public void PointClickEvent(Point point)
    {
        if(point is HubPoint)
        {
            Debug.Log("abcd");
            point.gameObject.GetComponent<HubPoint>().HubPointClickEvent();
        }
        else
        {
            if (TradeRouteManager.Instance.isRouteBeingCreated)
            {
                Debug.Log("Added to route");
                TradeRouteManager.Instance.currentlyCreatedRoute.AddToRoute(point);
            }
        }
    }
}
