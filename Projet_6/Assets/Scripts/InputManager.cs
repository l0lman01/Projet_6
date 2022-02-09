using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePosition = Input.mousePosition;
            
            Debug.Log($"Left click on: {mousePosition}");

            Camera mainCamera = Camera.main ;
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            Debug.Log($"Left click on: {mousePosition}/{mouseWorldPosition}");

           // GridManager.Instance.m_Grid;

            
        }


        /*if (Input.GetMouseButton(0))
        {
            Debug.Log("left click");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Stop left click");
        }
        


        if (Input.GetMouseButton(1))
        {
            Debug.Log("Right click");
        }*/
    }
}
