using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool m_isAlive = false;

    public int m_Neighbors = 0;

    private void Awake()
    {
      
    }
    private void OnMouseDown()
    {
        Debug.Log($"Click on {name} ");
    }

    private MeshRenderer meshRenderer;
}