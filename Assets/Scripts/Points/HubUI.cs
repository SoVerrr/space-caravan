using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HubUI : MonoBehaviour
{
    private HubPoint parentHub;
    private List<string> routeNames;
    [SerializeField] private GameObject routeNameInput;
    [SerializeField] private GameObject routeButtonPrefab;
    [SerializeField] private GameObject confirmRouteField;
    [SerializeField] private GameObject removeRouteButton;
    [SerializeField] private GameObject newRouteButton;
    [SerializeField] private GameObject routeButtonParent;

    private bool confirmRoute = false;
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
    public void RouteButton()
    {

    }
    private void PopulateNameList()
    {
        foreach (var item in parentHub.routeList)
        {
            Debug.Log(item.RouteName);
        }
    }

    private void CreateRouteButtons()
    {
        PopulateNameList();
        for(int i = 0; i < parentHub.routeList.Count; i++)
        {
            Vector3 position = new Vector3(-375, 275 - 155*i, 0);
            var button = Instantiate(routeButtonPrefab);
            button.GetComponent<ButtonMaker>().SetText(parentHub.routeList[i].RouteName);
            button.transform.parent = routeButtonParent.transform;
            button.transform.localPosition = position;
            button.transform.localScale = Vector3.one;
        }
        newRouteButton.transform.localPosition = new Vector3(-375, 275 - 150 * parentHub.routeList.Count, 0);
    }
    private void DestroyRouteButtons()
    {
        foreach(Transform child in routeButtonParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void ConfirmRouteNameButton()
    {
        confirmRoute = true;
        TradeRouteManager.Instance.FinishCurrentRoute(routeNameInput.GetComponent<TMP_InputField>().text);
        confirmRouteField.SetActive(false);
        parentHub.UI.SetActive(false);
    }

    private void OnEnable()
    {
        parentHub = TradeRouteManager.Instance.parentHub;
        if (parentHub.routeList.Count > 0)
        {
            CreateRouteButtons();
        }
        if (TradeRouteManager.Instance.isRouteBeingCreated)
        {
            confirmRouteField.SetActive(true);
        }
    }

    private void OnDisable()
    {
        DestroyRouteButtons();
        parentHub = null;
        if (!TradeRouteManager.Instance.isRouteBeingCreated)
            TradeRouteManager.Instance.parentHub = null;
    }
}
