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
        CloseWindow();

    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        TradeRouteManager.Instance.parentHub = null;
    }
}
