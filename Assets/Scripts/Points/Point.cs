using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Point : MonoBehaviour
{
    protected int xCoordinate, yCoordinate;
    [SerializeField] protected SpaceGrid grid;
    protected DetectCollisions detectCollisions;
    abstract public GameObject InstantiatePoint(int x, int y);
    abstract public void Functionality(Inventory truckInventory);
    public Vector2Int GetPointPosition()
    {
        return new Vector2Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.z);
    }
    public void PointClickEvent(Point point)
    {
        if(point is HubPoint)
        {
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
    protected virtual void Awake()
    {
        detectCollisions = GetComponent<DetectCollisions>();
    }
    protected virtual void Update()
    {
        Transform collision = detectCollisions.IsCollidingUpward();
        if(collision != null)
        {
            Inventory inv = collision.GetComponent<Inventory>();
            if(inv != null)
            {
                Functionality(inv);
            }
        }
    }
}
