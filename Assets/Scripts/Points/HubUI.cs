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
    [SerializeField] private GameObject finishRouteButton;
    public static int buttonPressedIndex;
    // Start is called before the first frame update

    public void CloseWindow()
    {
        HubPoint.isUiEnabled = false;
        transform.gameObject.SetActive(false);
    }

    public void FinishRoute()
    {
        gameObject.SetActive(true);
        finishRouteButton.SetActive(false);
    }

    public void NewRouteButton()
    {
        TradeRouteManager.Instance.isRouteBeingCreated = true;
        TradeRouteManager.Instance.StartNewRoute();
        finishRouteButton.SetActive(true);
        CloseWindow();
    }

    public void RouteButton()
    {
        removeRouteButton.SetActive(true);
        removeRouteButton.transform.localPosition = new Vector3(-150, 275 - 150 * buttonPressedIndex, 0);
    }
    public void RemoveRouteButton()
    {
        parentHub.routeList.RemoveAt(buttonPressedIndex);
        UpdateRouteButtons();
        removeRouteButton.SetActive(false);
    }

    private void CreateRouteButtons()
    {
        for(int i = 0; i < parentHub.routeList.Count; i++)
        {
            Vector3 position = new Vector3(-375, 275 - 155*i, 0);
            var button = Instantiate(routeButtonPrefab);

            button.GetComponent<ButtonMaker>().SetText(parentHub.routeList[i].RouteName);
            button.transform.parent = routeButtonParent.transform;
            button.transform.localPosition = position;
            button.transform.localScale = Vector3.one;
            button.GetComponent<ButtonMaker>().ButtonIndex = i; 
        }
        newRouteButton.transform.localPosition = new Vector3(-375, 275 - 150 * parentHub.routeList.Count, 0);
    }

    private void UpdateRouteButtons()
    {
        DestroyRouteButtons();
        CreateRouteButtons();
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
        TradeRouteManager.Instance.FinishCurrentRoute(routeNameInput.GetComponent<TMP_InputField>().text);
        confirmRouteField.SetActive(false);
        parentHub.UI.SetActive(false);
    }

    private void OnEnable()
    {
        UIManager.Instance.isUIOpen = true;
        newRouteButton.transform.localPosition = new Vector3(-375, 275, 0);
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
        UIManager.Instance.isUIOpen = false;
        DestroyRouteButtons();
        parentHub = null;
        if (!TradeRouteManager.Instance.isRouteBeingCreated)
            TradeRouteManager.Instance.parentHub = null;
    }
}
