using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    string itemName;
    string itemID;
    int maxPrice;
    int minPrice;
    string objectType; //Raw material or processing result
    
    public Item(RawMaterial material)
    {
        itemName = material.materialName;
        itemID = material.itemID;
        maxPrice = material.maxPrice;
        minPrice = material.minPrice;
        objectType = "material";
    }

}
