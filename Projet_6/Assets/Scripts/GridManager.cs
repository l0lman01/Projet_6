using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    #region Show in Inspector
    [SerializeField] private GameObject _cellPrefab;
    #endregion

    #region Public
    [Range(0, 50)]
    public int m_NumCol = 10;

    [Range(0, 50)]
    public int m_NumRows = 10;
    public GameObject[,] m_Grid;

    #endregion

    #region Singleton
    public static GridManager Instance;
    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);           
        }
        else
        {
            Destroy(gameObject);
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
        m_Grid = new GameObject[m_NumCol, m_NumRows];

        for (int row = 0; row < m_NumRows; row++)
        {
            for (int col = 0; col < m_NumCol; col++)
            {
                Vector3 pos = new Vector3(col, row, 0);

                GameObject clone = Instantiate(_cellPrefab, pos, Quaternion.identity);
                clone.name = $"[{row},{col}]";
                m_Grid[col, row] = clone;
            }
        }
    }
    #endregion
    public void ChangeRows(float value)
    {    
        m_NumRows = (int)value;
        GenerateGrid();
    }
    public void ChangeCols(float value)
    {
        m_NumCol= (int)value;
        GenerateGrid();
    }
}