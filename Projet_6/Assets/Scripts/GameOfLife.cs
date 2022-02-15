using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class GameOfLife : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private Material _aliveMaterial;
    [SerializeField] private Material _deadMaterial;

<<<<<<< Updated upstream
=======
    [Range(0, 20)]
>>>>>>> Stashed changes
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            CountNeighbors();
        }
<<<<<<< Updated upstream
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Speed(float newSpeed)
    {
        period = newSpeed;
    }

=======
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
        period = value;        
    }

    public void ResetGrid()
    {
        Object obj = FindObjectOfType(typeof(GridManager));
        _gridManager = (GridManager)obj;
        _gridManager = obj as GridManager;
        _gridManager = FindObjectOfType<GridManager>();
        FindObjectOfType<GridManager>();

        for (int i = 0; i < _gridManager.m_NumRows; i++)
        {
            for (int j = 0; j < _gridManager.m_NumCol; j++)
            {
                var cell = GridManager.Instance.m_Grid[j, i];                
                cell.m_isAlive = false;               
            }
        }
    }

>>>>>>> Stashed changes
    public void CountNeighbors()
    {
        Object obj = FindObjectOfType(typeof(GridManager));
        _gridManager = (GridManager)obj;
        _gridManager = obj as GridManager;
        _gridManager = FindObjectOfType<GridManager>();
        FindObjectOfType<GridManager>();

        for (int i = 0; i < _gridManager.m_NumRows; i++)
        {
            for (int j = 0; j < _gridManager.m_NumCol; j++)
            {
                var cell = GridManager.Instance.m_Grid[j, i];
                var meshRenderer = cell.GetComponentInChildren<MeshRenderer>();

                cell.m_Neighbors = 0;

                if (i - 1 >= 0 && i - 1 < _gridManager.m_NumRows)//down
                {
                    var otherCell = GridManager.Instance.m_Grid[j, i - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                else
                {
                    var otherCell = GridManager.Instance.m_Grid[j, _gridManager.m_NumRows - 1];
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
                else
                {
                    var otherCell = GridManager.Instance.m_Grid[j, 0];
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
                else
                {
                    var otherCell = GridManager.Instance.m_Grid[_gridManager.m_NumCol - 1, i];
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
                else
                {
                    var otherCell = GridManager.Instance.m_Grid[0, i];
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
                else if (i + 1 >= 0 && i + 1 < _gridManager.m_NumRows &&
                         (j - 1 < 0 || j - 1 >= _gridManager.m_NumRows))
                {
                    var otherCell = GridManager.Instance.m_Grid[_gridManager.m_NumCol - 1, i + 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                else if ((i + 1 < 0 || i + 1 >= _gridManager.m_NumRows) &&
                    j - 1 >= 0 && j - 1 < _gridManager.m_NumRows)
                {
                    var otherCell = GridManager.Instance.m_Grid[j - 1, 0];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                else if ((i + 1 < 0 || i + 1 >= _gridManager.m_NumRows) &&
                    (j - 1 < 0 || j - 1 >= _gridManager.m_NumRows))
                {
                    var otherCell = GridManager.Instance.m_Grid[_gridManager.m_NumCol - 1, 0];
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
                else if (i + 1 >= 0 && i + 1 < _gridManager.m_NumRows &&
                    (j + 1 < 0 || j + 1 >= _gridManager.m_NumRows))
                {
                    var otherCell = GridManager.Instance.m_Grid[0, i + 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                else if ((i + 1 < 0 || i + 1 >= _gridManager.m_NumRows) &&
                    j + 1 >= 0 && j + 1 < _gridManager.m_NumRows)
                {
                    var otherCell = GridManager.Instance.m_Grid[j + 1, 0];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                else if ((i + 1 < 0 || i + 1 >= _gridManager.m_NumRows) &&
                    (j + 1 < 0 || j + 1 >= _gridManager.m_NumRows))
                {
                    var otherCell = GridManager.Instance.m_Grid[0,0];
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
                else if (i - 1 >= 0 && i - 1 < _gridManager.m_NumRows &&
                    (j - 1 < 0 || j - 1 >= _gridManager.m_NumRows))
                {
                    var otherCell = GridManager.Instance.m_Grid[_gridManager.m_NumCol - 1, i - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                else if ((i - 1 < 0 || i - 1 >= _gridManager.m_NumRows) &&
                    j - 1 >= 0 && j - 1 < _gridManager.m_NumRows)
                {
                    var otherCell = GridManager.Instance.m_Grid[j - 1, _gridManager.m_NumRows - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                else if ((i - 1 < 0 || i - 1 >= _gridManager.m_NumRows) &&
                    (j - 1 < 0 || j - 1 >= _gridManager.m_NumRows))
                {
                    var otherCell = GridManager.Instance.m_Grid[_gridManager.m_NumCol - 1, _gridManager.m_NumRows - 1]; ;
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
                else if (i - 1 >= 0 && i - 1 < _gridManager.m_NumRows &&
                    (j + 1 > 0 || j + 1 >= _gridManager.m_NumRows))
                {
                    var otherCell = GridManager.Instance.m_Grid[0, i - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                else if ((i - 1 < 0 || i - 1 >= _gridManager.m_NumRows) &&
                    j + 1 >= 0 && j + 1 < _gridManager.m_NumRows)
                {
                    var otherCell = GridManager.Instance.m_Grid[j + 1, _gridManager.m_NumRows - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
                else if ((i - 1 < 0 || i - 1 >= _gridManager.m_NumRows )&&
                    (j + 1 < 0 || j + 1 >= _gridManager.m_NumRows))
                {
                    var otherCell = GridManager.Instance.m_Grid[0 , _gridManager.m_NumRows - 1];
                    if (otherCell.m_isAlive == true)
                    {
                        cell.m_Neighbors += 1;
                    }
                }
            }
        }

        for (int i = 0; i < _gridManager.m_NumRows; i++)
        {
            for (int j = 0; j < _gridManager.m_NumCol; j++)
            {
                var cell = GridManager.Instance.m_Grid[j, i];
                var meshRenderer = cell.GetComponentInChildren<MeshRenderer>();

                if (cell.m_Neighbors == 3)// 3 neighbors -> alive
                {
                    cell.m_isAlive = true;
                    meshRenderer.sharedMaterial = _aliveMaterial;
                }
                if (cell.m_Neighbors <= 1 || cell.m_Neighbors > 3)// 1 or more than 3 neighbors -> dead
                {
                    cell.m_isAlive = false;
                    meshRenderer.sharedMaterial = _deadMaterial;
                }
            }
<<<<<<< Updated upstream
        }
    }                
}
=======
        }       
    }                       
}
>>>>>>> Stashed changes
