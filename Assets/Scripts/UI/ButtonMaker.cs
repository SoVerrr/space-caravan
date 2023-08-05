using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonMaker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private int buttonIndex;
    public void SetText(string txt)
    {
        text.text = txt;
    }

    public int ButtonIndex
    {
        get { return buttonIndex; }
        set { buttonIndex = value; }
    }
    public void setUiButtonIndex()
    {
        HubUI.buttonPressedIndex = buttonIndex;
    }
}
