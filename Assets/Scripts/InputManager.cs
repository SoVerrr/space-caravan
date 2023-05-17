using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public Action<Vector3Int> OnMouseClick, OnMouseHold;
    public Action OnMouseUp;

    public LayerMask spaceMask;

    [SerializeField]
    Camera mainCamera;

    private void Update()
    {
        CheckClickDownEvent();
        CheckClickUpEvent();
        CheckClickHoldEvent();
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

    private void CheckClickHoldEvent()
    {
       
        if(Input.GetMouseButton(0)) // && EventSystem.current.IsPointerOverGameObject() == false
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
        if (Input.GetMouseButtonUp(0)) // && EventSystem.current.IsPointerOverGameObject() == false
        {
            OnMouseUp?.Invoke();
        }
    }

    private void CheckClickDownEvent()
    {
        if (Input.GetMouseButtonDown(0)) //  && EventSystem.current.IsPointerOverGameObject() == false
        {
            var position = RaycastSpace();

            if (position != null)
            {
                Debug.Log("ClickDown");
                OnMouseClick?.Invoke(position.Value);
            }
        }
    }
}
