using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataMaterial : PlanetData
{
    public int productionRate; 
    public string materialType;
    public PlanetDataMaterial(int prodRate, string matType)
    {
        productionRate = prodRate;
        materialType = matType;
    }
}