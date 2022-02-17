using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    #region Show in Inspector
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Cell _InvisibleCellPrefab;
    #endregion

    #region Public
    [Range(0, 50)]
    public int m_NumCol = 10;

    [Range(0, 50)]
    public int m_NumRows = 10;
    public Cell[,] m_Grid;

    #endregion
    private bool isInfinite = false;
    #region Singleton
    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            GenerateGrid();
        }
        else
        {
            Destroy(gameObject);
            GenerateGrid();

        }
    }
    public void GenerateGrid()
    {
       if (m_Grid != null)
       {
            foreach(var cell in m_Grid)
            {
                Destroy(cell.gameObject);
            }
       }

        m_Grid = new Cell[m_NumCol, m_NumRows];

        for (int row = 0; row < m_NumRows; row++)
        {
            for (int col = 0; col < m_NumCol; col++)
            {
                if (isInfinite)
                {
                    if ((col > 10 && col < m_NumCol - 10) && (row > 10 && row < m_NumRows - 10))
                    {
                        Vector3 pos = new Vector3(col, row, 0);
                        Cell clone = Instantiate(_cellPrefab, pos, Quaternion.identity);
                        clone.name = $"[{row},{col}]";
                        m_Grid[col, row] = clone;
                    }
                    else
                    {
                        Vector3 pos = new Vector3(col, row, 0);
                        Cell border = Instantiate(_InvisibleCellPrefab, pos, Quaternion.identity);
                        border.name = $"[{row},{col}]";
                        m_Grid[col, row] = border;
                    }
                }
                else
                {                    
                    Vector3 pos = new Vector3(col, row, 0);
                    Cell clone = Instantiate(_cellPrefab, pos, Quaternion.identity);
                    clone.name = $"[{row},{col}]";
                    m_Grid[col, row] = clone;                
                }
               
            }
        }
    }
    #endregion
    public void Infinite()
    {
        if (isInfinite)
        {
            isInfinite = false;
        }
        else
        {
            isInfinite = true;
        }
    }
    public void ChangeRows(float rows)
    {
        if (isInfinite)
        {
            m_NumRows = (int)rows + 10;
        }
        else
        {
            m_NumRows = (int)rows;
        }
        GenerateGrid();
    }
    public void ChangeCols(float cols)
    {
        if (isInfinite)
        {
            m_NumCol = (int)cols + 10;
        }
        else
        {
            m_NumCol = (int)cols;
        }
        GenerateGrid();
    }
}