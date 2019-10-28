using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnits : MonoBehaviour {

    public GameObject Unit;
    private int counter;
    private int spawnCounter = 1000000000;
    void Start()
    {
        counter = 0;
    }
    void Update()
    {
        if (counter % spawnCounter == 0)
        {

            GameObject newUnit = Instantiate(Unit);
            newUnit.transform.position = transform.position;

        }
        counter++;

    }
}
