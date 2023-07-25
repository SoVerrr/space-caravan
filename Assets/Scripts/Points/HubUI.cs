using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void CloseWindow()
    {
        HubPoint.isUiEnabled = false;
        transform.gameObject.SetActive(false);
    }
    public void NewRouteButton()
    {
        TradeRouteManager.Instance.isRouteBeingCreated = true;
        TradeRouteManager.Instance.StartNewRoute();
        CloseWindow();
    }
    private void OnEnable()
    {
        if (TradeRouteManager.Instance.isRouteBeingCreated)
        {
            TradeRouteManager.Instance.FinishCurrentRoute();

        }
    }
    private void OnDisable()
    {
        if(!TradeRouteManager.Instance.isRouteBeingCreated)
            TradeRouteManager.Instance.parentHub = null;
    }
}
