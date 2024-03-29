using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public Action<Vector3Int> OnMouseClick, OnMouseHold;
    public Action OnMouseUp;
    public Action<Point> OnPointClick, OnHubRightClick;
    public Action<TruckManager> OnTruckClick;
    public LayerMask spaceMask;
    private int roadCounter;
    [SerializeField]
    Camera mainCamera;
    public SpaceGrid spacerGrid;

    private void Update()
    {
        CheckClickDownEvent();
        CheckClickUpEvent();
        CheckClickHoldEvent();
        CheckPointClickEvent();
        CheckTruckClickEvent();
        roadCounter = spacerGrid.GetRoadCounter();
    }

    private Vector3Int? RaycastSpace()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // Wskazuje kamera tam gdzie klikniete
        
        if (Physics.Raycast(ray, out hit))
        {
            
            Vector3Int positionInt = Vector3Int.RoundToInt(hit.point);
            return positionInt;
        }

    
        return null;
    }
    private Transform? RaycastObject()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // Wskazuje kamera tam gdzie klikniete

        if (Physics.Raycast(ray, out hit))
        {

            Transform objectHit = hit.transform;
            if(objectHit)
                return objectHit;
        }


        return null;
    }
    private void CheckClickHoldEvent()
    {
       
        if(Input.GetMouseButton(0) && roadCounter > 0  && UIManager.Instance.isUIOpen == false)
        {
            var position = RaycastSpace();

            if(position != null)
            {
                OnMouseHold?.Invoke(position.Value);
            }
        }
    }

    private void CheckClickUpEvent()  
    {
        if (Input.GetMouseButtonUp(0) && UIManager.Instance.isUIOpen == false)
        {
            OnMouseUp?.Invoke();
        }
    }

    private void CheckClickDownEvent()
    {
        if (Input.GetMouseButtonDown(0) && roadCounter > 0 && UIManager.Instance.isUIOpen == false)
        {
            var position = RaycastSpace();
            var objectHit = RaycastObject();
            if (position != null)
            {
                OnMouseClick?.Invoke(position.Value);
            }

            
        }
    }

    private void CheckPointClickEvent()
    {
        if (Input.GetMouseButtonDown(0) && TradeRouteManager.Instance.isRouteBeingCreated)
        {
            Transform objectHit = RaycastObject();
            var point = objectHit.gameObject.GetComponent<Point>();
            if (point)
                OnPointClick?.Invoke(point);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Transform objectHit = RaycastObject();
            var point = objectHit.gameObject.GetComponent<Point>();
            if (objectHit.gameObject.GetComponent<HubPoint>() != null)
                OnPointClick?.Invoke(objectHit.gameObject.GetComponent<HubPoint>());
        }

    }

    private void CheckTruckClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform objectHit = RaycastObject();
            var truck = objectHit.gameObject.GetComponent<TruckManager>();
            if (truck)
                OnTruckClick?.Invoke(truck);
        }
    }

}
