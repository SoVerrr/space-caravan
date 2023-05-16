using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    private Camera camera;
    private LineRenderer newLine;

    public GameObject planetOne;
    private GameObject planetTwo;

    private bool firstTouch = true;

    private Vector2 firstPoint;

    private void Awake()
    {
        newLine = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        newLine.positionCount = 2;

    }

    // Update is called once per frame
    void Update()
    {
        planetOne = DetectObjectWithRaycast();
        Transform first = planetOne.transform;


        if (Input.GetMouseButtonDown(0))
        {
            if (firstTouch)
            {
                first = planetOne.transform;
                Debug.Log("First Click");
                firstTouch = false;
            } else
            {
                Transform second = planetOne.transform;
                Debug.Log("Second Click");
                newLine.SetPosition(0, first.position);
                newLine.SetPosition(1, second.position);
                firstTouch = true;
            }
        }

    }

    public GameObject DetectObjectWithRaycast()
    {
        GameObject p = planetOne;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);

                p = hit.collider.gameObject;
            }
        }

        return p;
    }

    void DrawLine(Transform firstT, Transform secondT) { 
        
    }
}

    
