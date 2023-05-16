using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Planet : MonoBehaviour
{
    private int xCoordinate, yCoordinate;
    abstract public void InstantiateObject(int x, int y);
}
