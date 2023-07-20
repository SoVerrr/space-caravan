using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubUI : MonoBehaviour
{
    static private HubPoint hub;
    static public bool isRouteBeingCreated = false;
    // Start is called before the first frame update
    public void CloseWindow()
    {
        HubPoint.isUiEnabled = false;
        transform.gameObject.SetActive(false);
    }
    public void NewRouteButton()
    {
        HubPoint tempHub = hub;
        isRouteBeingCreated = true;
        CloseWindow();

    }
    static public void SetParentHub(HubPoint parentHub) //parent hub refers to the hub from which the interface was opened
    {
        hub = parentHub;
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        hub = null;
    }
}
