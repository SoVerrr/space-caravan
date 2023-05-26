using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private PlanetManager planetManager;

    private void OnEnable()
    {
        Timer.timeChanged += TimeCheck;
    }

    private void OnDisable()
    {
        Timer.timeChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
        if (Timer.time > 1)
        {
            if (Timer.time % 5 == 0)
            {
                Debug.Log("hej minê³o 5 sekund");
                planetManager.GeneratePlanet(planetManager.materialPlanet,new PlanetDataMaterial(5, "stone"));
            }

            if (Timer.time % 15 == 0)
            {
                Debug.Log("hej minê³o 15 sekund");
            }

        }
    }
    private void Start()
    {
    }
}
