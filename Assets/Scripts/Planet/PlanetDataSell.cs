using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataSell : PlanetData
{
    public string[] materialsBought;
    public int[] materialPrices;

    public PlanetDataSell(string[] materialsBought, int[] materialPrices)
    {
        this.materialsBought = materialsBought;
        this.materialPrices = materialPrices;
    }

}
