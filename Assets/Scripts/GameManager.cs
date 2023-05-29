using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputManager inputManager;
    public RouteManager routeManager;

    private void Start()
    {
        inputManager.OnMouseClick += routeManager.PlaceRoute;
        inputManager.OnMouseHold += routeManager.PlaceRoute;
        inputManager.OnMouseUp += routeManager.FinishPlacingRoute;
    }

    //private void HandleMouseClick(Vector3Int position)
    //{
    //    Debug.Log(position);
    //    routeManager.PlaceRoute(position);
    //}

}
