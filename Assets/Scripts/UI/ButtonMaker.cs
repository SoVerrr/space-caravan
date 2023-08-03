using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonMaker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public void SetText(string txt)
    {
        text.text = txt;
    }
}
