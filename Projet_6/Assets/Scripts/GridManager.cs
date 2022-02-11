using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Show in Inspector
    [SerializeField] private GameObject _cellPrefab;
    #endregion

    #region Public
    [Range(0, 50)]
    public int m_NumCol = 10;

    [Range(0, 50)]
    public int m_NumLines = 10;
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
        GenerateGrid();
    }
    private void GenerateGrid()
    {
        m_Grid = new GameObject[m_NumCol, m_NumLines];

        for (int row = 0; row < m_NumLines; row++)
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
   
}