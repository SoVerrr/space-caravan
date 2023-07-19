using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubUI : MonoBehaviour
{
    private HubPoint hub;
    // Start is called before the first frame update
    public void CloseWindow()
    {
        HubPoint.isUiEnabled = false;
        transform.gameObject.SetActive(false);
    }
    static public void SetParentHub()
    {

    }
    private void Start()
    {
        
    }
}
