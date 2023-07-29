using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputManager inputManager;
    public RouteManager routeManager;
    [SerializeField] private GameObject HubUI;
    [SerializeField] private Point point;
    [SerializeField] private TruckManager truck;
    private void Start()
    {
        inputManager.OnMouseClick += routeManager.PlaceRoute;
        inputManager.OnMouseHold += routeManager.PlaceRoute;
        inputManager.OnMouseUp += routeManager.FinishPlacingRoute;
        inputManager.OnPointClick += point.PointClickEvent;
        inputManager.OnHubRightClick += point.HubRightClickEvent;
        inputManager.OnTruckClick += truck.TruckClickEvent;
    }

    //private void HandleMouseClick(Vector3Int position)
    //{
    //    Debug.Log(position);
    //    routeManager.PlaceRoute(position);
    //}
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && TradeRouteManager.Instance.isRouteBeingCreated)
        {
            HubUI.SetActive(true);
        }
    }
}
