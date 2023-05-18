using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataHub : PlanetData
{
    public string[] materialsRequired;
    public string[] products;
    public int productionTime;
    public PlanetDataHub(string[] materialsRequired, string[] products, int productionTime)
    {
        this.materialsRequired = materialsRequired;
        this.products = products;
        this.productionTime = productionTime;
    }
}

