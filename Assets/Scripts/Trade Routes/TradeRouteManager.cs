using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeRouteManager : MonoBehaviour
{
    public static TradeRouteManager Instance { get; private set; }
    public bool isRouteBeingCreated = false;
    public TradeRoute currentlyCreatedRoute;
    public HubPoint parentHub;
    public void SetParentHub(HubPoint hub)
    {
        parentHub = hub;
    }
    public void StartNewRoute()
    {
        currentlyCreatedRoute = new TradeRoute();
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
}
