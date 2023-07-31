using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private Transform lastCollided;
    public Transform IsCollidingUpward()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.up * 10);
        Debug.DrawRay(transform.position, Vector3.up, Color.red, 10);
        if (Physics.Raycast(ray, out hit, 10) && hit.transform != lastCollided)
        {
            lastCollided = hit.transform;
            Transform objectHit = hit.transform;
            if (objectHit)
                return objectHit;
        }


        return null;
    }
}
