using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


///USAGE
//// getItemValue  to get number of items of certain type in the invertory
//// addItem   to increase number of items of certain type  by a chosen number up to a maxVal

public class Inventory : MonoBehaviour
{
    int maxVal = 255;
    Dictionary<string, int> Item = new Dictionary<string, int>()
    {
        {"rock", 0},
        {"coal", 0}
    };

    public int getItemValue(string itemName)
    {
        return Item[itemName];
    }

    public void addItem(string itemName, int addedVal)
    {
        if(addedVal>0)
        {
            // Limits addition up to maxVal            
            Item[itemName] = maxVal - (  Math.Abs(maxVal-Item[itemName]-addedVal) + (maxVal-Item[itemName]-addedVal)  ) / 2;
        }
    }


}
