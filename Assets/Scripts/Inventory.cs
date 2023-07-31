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
        {"coal", 0},
        {"iron", 0},
        {"gold", 0},
        {"thing1", 0},
        {"thing2", 0},
        {"thing3", 0}
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

    public void substractItem(string itemName, int substractedVal)
    {
        if(substractedVal>0)
        {
            // Limits substraction down to 0            
            Item[itemName] = ( Math.Abs(Item[itemName]-substractedVal) + (Item[itemName]-substractedVal) ) / 2;
        }
    }

}
