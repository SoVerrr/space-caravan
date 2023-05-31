using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    // Start is called before the first frame update
    

    public void move_forward()
    {
        Vector3 currentPosition = transform.position;
        transform.localPosition = Vector3.MoveTowards(currentPosition, new Vector3(currentPosition[0]+1, 0, currentPosition[2]+1), 1);
    }
}
