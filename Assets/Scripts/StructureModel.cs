using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that allow as to call method that can change exsisting prefab and rotate it
// this class will be parent
public class StructureModel : MonoBehaviour 
{
    float yHeight = 0; // height of our prefab

    public void CreateStructure(GameObject structure)
    {
        var model = Instantiate(structure, transform);
        yHeight = model.transform.position.y;
    }

    public void SwapStructure(GameObject structure, Quaternion rotation)
    {
        foreach(Transform child in transform) // we call foreach because we can have more than one model in this class;
        {
            Destroy(child.gameObject);
        }

        var model = Instantiate(structure, transform);
        model.transform.localPosition = new Vector3(0, yHeight, 0); // same height as old object
        model.transform.localRotation = rotation; // new model is correctly rotated
    }
}
