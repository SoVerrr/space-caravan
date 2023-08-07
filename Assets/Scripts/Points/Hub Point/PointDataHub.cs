using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDataHub : PointData
{
    public string[] materialsBought;
    public int[] materialPrices;

    public PointDataHub(string[] materialsBought, int[] materialPrices)
    {
        this.materialsBought = materialsBought;
        this.materialPrices = materialPrices;
    }

}
