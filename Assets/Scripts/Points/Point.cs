using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Point : MonoBehaviour
{
    private int xCoordinate, yCoordinate;
    abstract public void InstantiatePoint(int x, int y, PointData data);
}
