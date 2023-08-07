using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUBPointPlaceTruck : MonoBehaviour
{
    [SerializeField] private GameObject truckObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject truck = Instantiate(truckObject, new Vector3(transform.position.x+1, 1, transform.position.y), truckObject.transform.rotation);
        truck.GetComponent<TruckManager>().targetPosition = new Vector3(transform.position[0], 0 , transform.position[2]);
    }

    // Update is called once per frame
    
}
