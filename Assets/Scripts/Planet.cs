using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Planet : MonoBehaviour
{
    private int xCoordinate, yCoordinate;
    public void InstantiateObject(int x, int y);
}
