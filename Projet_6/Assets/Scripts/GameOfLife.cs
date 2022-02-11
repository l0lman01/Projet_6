using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    [Range(0, 20)]
    public float speed = 5f;

    private float timer = 0;


    void Update()
    {
        //CountNeighbour();



    }


    public void simulationSpeed(float newSpeed)
    {
        speed = newSpeed;
        if (timer < speed)
        {
            timer = 0f;
        }
        else{
            timer += Time.deltaTime;
        }
    }
}