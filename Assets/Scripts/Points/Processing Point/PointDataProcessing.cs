using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDataProcessing : PointData
{
    public string[] materialsRequired;
    public string[] products;
    public int productionTime;
    public PointDataProcessing(string[] materialsRequired, string[] products, int productionTime)
    {
        this.materialsRequired = materialsRequired;
        this.products = products;
        this.productionTime = productionTime;
    }
}

