using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public InputManager inputManager;
    public RouteManager routeManager;
    public int score = 0;
    [SerializeField] private GameObject HubUI;
    [SerializeField] private Point point;
    [SerializeField] private TruckManager truck;
    [SerializeField] public float occuranceModifier;
    [SerializeField] public ItemList itemList;
    private void Start()
    {
        itemList.InitializeItemList();
        inputManager.OnMouseClick += routeManager.PlaceRoute;
        inputManager.OnMouseHold += routeManager.PlaceRoute;
        inputManager.OnMouseUp += routeManager.FinishPlacingRoute;
        inputManager.OnPointClick += point.PointClickEvent;
        inputManager.OnTruckClick += truck.TruckClickEvent;
    }

    //private void HandleMouseClick(Vector3Int position)
    //{
    //    Debug.Log(position);
    //    routeManager.PlaceRoute(position);
    //}
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && TradeRouteManager.Instance.isRouteBeingCreated)
        {
            HubUI.SetActive(true);
        }
    }
}
