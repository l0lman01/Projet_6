using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InfiniteGrid : MonoBehaviour
{
    [SerializeField] private GridManager _gridM;
    [SerializeField] private Material _aliveM;
    [SerializeField] private Material _deadM;

    [Range(0, 20)]
    private float nextAction = 0.0f;
    public float step = 0.1f;

    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Time.time > nextAction)
        {
            nextAction += step;
            // execute block of code here
            NormalNeighbors();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void ChangeSpeed(float value)
    {
        step = value;
    }

    public void ResetGrid()
    {
        Object obj = FindObjectOfType(typeof(GridManager));
        _gridM = (GridManager)obj;
        _gridM = obj as GridManager;
        _gridM = FindObjectOfType<GridManager>();
        FindObjectOfType<GridManager>();

        for (int i = 0; i < _gridM.m_NumRows; i++)
        {
            for (int j = 0; j < _gridM.m_NumCol; j++)
            {
                var cell = GridManager.Instance.m_Grid[j, i];
                cell.m_isAlive = false;
            }
        }
    }

    public void NormalNeighbors()
    {
        Object obj = FindObjectOfType(typeof(GridManager));
        _gridM = (GridManager)obj;
        _gridM = obj as GridManager;
        _gridM = FindObjectOfType<GridManager>();
        FindObjectOfType<GridManager>();

        for (int i = 0; i < _gridM.m_NumRows; i++)
        {
            for (int j = 0; j < _gridM.m_NumCol; j++)
            {
                var cell = GridManager.Instance.m_Grid[j, i];
                var meshRenderer = cell.GetComponentInChildren<MeshRenderer>();

                cell.m_Neighbors = 0;

                if (i - 1 >= 0 && i - 1 < _gridM.m_NumRows)//down
                {
                    var otherCell = GridManager.Instance.m_Grid[j, i - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }               
                if (i + 1 >= 0 && i + 1 < _gridM.m_NumRows)//up
                {
                    var otherCell = GridManager.Instance.m_Grid[j, i + 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (j - 1 >= 0 && j - 1 < _gridM.m_NumRows)//left
                {
                    var otherCell = GridManager.Instance.m_Grid[j - 1, i];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (j + 1 >= 0 && j + 1 < _gridM.m_NumRows)//right
                {
                    var otherCell = GridManager.Instance.m_Grid[j + 1, i];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (i + 1 >= 0 && i + 1 < _gridM.m_NumRows &&
                    j - 1 >= 0 && j - 1 < _gridM.m_NumRows)//diagonal up left
                {
                    var otherCell = GridManager.Instance.m_Grid[j - 1, i + 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (i + 1 >= 0 && i + 1 < _gridM.m_NumRows &&
                    j + 1 >= 0 && j + 1 < _gridM.m_NumRows)//diagonal up right
                {
                    var otherCell = GridManager.Instance.m_Grid[j + 1, i + 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (i - 1 >= 0 && i - 1 < _gridM.m_NumRows &&
                    j - 1 >= 0 && j - 1 < _gridM.m_NumRows)//diagonal down left
                {
                    var otherCell = GridManager.Instance.m_Grid[j - 1, i - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (i - 1 >= 0 && i - 1 < _gridM.m_NumRows &&
                    j + 1 >= 0 && j + 1 < _gridM.m_NumRows)//diagonal down right
                {
                    var otherCell = GridManager.Instance.m_Grid[j + 1, i - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
              
            }
        }
        for (int i = 0; i < _gridM.m_NumRows; i++)
        {
            for (int j = 0; j < _gridM.m_NumCol; j++)
            {
                var cell = GridManager.Instance.m_Grid[j, i];
                var meshRenderer = cell.GetComponentInChildren<MeshRenderer>();

                if (cell.m_Neighbors == 3)// 3 neighbors -> alive
                {
                    cell.m_isAlive = true;
                    meshRenderer.sharedMaterial = _aliveM;
                }
                if (cell.m_Neighbors <= 1 || cell.m_Neighbors > 3)// 1 or more than 3 neighbors -> dead
                {
                    cell.m_isAlive = false;
                    meshRenderer.sharedMaterial = _deadM;
                }
            }
        }
    }
}
