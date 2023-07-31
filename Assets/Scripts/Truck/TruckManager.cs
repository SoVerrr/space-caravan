using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckManager : MonoBehaviour
{
    // Start is called before the first frame update
    TruckMovement TruckMovement;
    public Vector3 currentPosition;
    public Vector3 targetPosition = new Vector3(0,0,0);
    [SerializeField] private GameObject inventoryUI;
    static public bool isUiEnabled = false;

    void Start()
    {
        Inventory truckInventory = new Inventory();

        //TruckMovement = new TruckMovement();
        
        truckInventory.addItem("coal", 40);
        truckInventory.addItem("coal", 49);
        truckInventory.addItem("coal", 999999);
        // Instantiate(gameObject, new Vector3(1, 0, 1), Quaternion.identity);
        //TruckMovement.move_forward();
        
        //transform.localPosition = Vector3.MoveTowards(currentPosition, new Vector3(currentPosition[0]+10, 0, currentPosition[2]+10), 0.5f);
    }

    //void moveByTile(Vector3 target)
    //{
    //    currentPosition = transform.position;
    //    transform.position = Vector3.MoveTowards(currentPosition, target, 0.1f*Time.deltaTime);
    //    Debug.Log("truck pos: ");Debug.Log(transform.position);
    //}

    public void TruckClickEvent(TruckManager truck)
    {
        Debug.Log("Truck clicked!!!");

        truck.inventoryUI.SetActive(!isUiEnabled);
        isUiEnabled = !isUiEnabled;

    }
    private void SetRotation()
    {
        transform.LookAt(currentPosition + GetComponent<TruckMovement>().GetCurrentTarget());
    }
    // Update is called once per frame
    void Update()
    {
        SetRotation();
    }
}
