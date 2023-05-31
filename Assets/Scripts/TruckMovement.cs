using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Inventory truckInventory = new Inventory();
        
        truckInventory.addItem("coal", 40);
        Debug.Log(truckInventory.getItemValue("coal"));
        truckInventory.addItem("coal", 49);
        Debug.Log(truckInventory.getItemValue("coal"));
        truckInventory.addItem("coal", 999999);
        Debug.Log(truckInventory.getItemValue("coal"));
        // Instantiate(gameObject, new Vector3(1, 0, 1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
