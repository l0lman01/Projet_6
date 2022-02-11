using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class GameOfLife : MonoBehaviour
{
    public float _stepDelay;
    [SerializeField] private GridManager _gridManager;
   
    private void Awake()
    {
     
        Object obj = FindObjectOfType(typeof(GridManager));
        _gridManager = (GridManager)obj;
        _gridManager = obj as GridManager;
        _gridManager = FindObjectOfType<GridManager>();
        FindObjectOfType<GridManager>();

        
    }

    //private void SimulationStep()
    //{
    //    Debug.Log("SimulationStep");

    //    int n = CountNeighbors(col, row);
    //}

    public void CountNeighbors()
{       
        for (int i = 0; i < _gridManager.m_NumRows; i++)
        {
            for (int j = 0; j < _gridManager.m_NumCol; j++)
            {
                var cell = GridManager.Instance.m_Grid[j, i];

                if (i - 1 >= 0 && i - 1 < _gridManager.m_NumRows)//down
                {
                    var otherCell = GridManager.Instance.m_Grid[j, i - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (i + 1 >= 0 && i + 1 < _gridManager.m_NumRows)//up
                {
                    var otherCell = GridManager.Instance.m_Grid[j, i + 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (j - 1 >= 0 && j - 1 < _gridManager.m_NumRows)//left
                {
                    var otherCell = GridManager.Instance.m_Grid[j - 1, i];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (j + 1 >= 0 && j + 1 < _gridManager.m_NumRows)//right
                {
                    var otherCell = GridManager.Instance.m_Grid[j + 1, i];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (i + 1 >= 0 && i + 1 < _gridManager.m_NumRows &&
                    j - 1 >= 0 && j - 1 < _gridManager.m_NumRows)//diagonal up left
                {
                    var otherCell = GridManager.Instance.m_Grid[j - 1, i + 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (i + 1 >= 0 && i + 1 < _gridManager.m_NumRows &&
                    j + 1 >= 0 && j + 1 < _gridManager.m_NumRows)//diagonal up right
                {
                    var otherCell = GridManager.Instance.m_Grid[j + 1, i + 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                if (i - 1 >= 0 && i - 1 < _gridManager.m_NumRows &&
                    j - 1 >= 0 && j - 1 < _gridManager.m_NumRows)//diagonal down left
                {
                    var otherCell = GridManager.Instance.m_Grid[j - 1, i - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;                      
                    }
                }
                if (i - 1 >= 0 && i - 1 < _gridManager.m_NumRows &&
                    j + 1 >= 0 && j + 1 < _gridManager.m_NumRows)//diagonal down right
                {
                    var otherCell = GridManager.Instance.m_Grid[j + 1, i - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;                        
                    }
                }
                if (cell.m_Neighbors == 3)// 3 neighbors -> alive
                {
                    cell.m_isAlive = true;
                }
                if (cell.m_Neighbors == 1 || cell.m_Neighbors > 3)// 1 or more than 3 neighbors -> dead
                {
                    cell.m_isAlive = false;
                }
                

            }
        }
    }                
        
}
