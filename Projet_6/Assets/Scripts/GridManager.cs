using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    #region Show in Inspector

    [SerializeField]
    [Range(0,50)]
    private int _numCol = 10;

    [SerializeField]
    [Range(0, 50) ]
    private int _numLines = 10;

    [SerializeField]
    private GameObject _cellPrefab;

    #endregion



    #region Public

    public GameObject[,] m_Grid;
    
    #endregion


    // Init sin los otros componenetes
    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);

        }
        GenerateGrid();
    }
    private void GenerateGrid()
    {
        m_Grid = new GameObject[_numCol, _numLines];

        for (int line = 0; line < _numLines; line++)
        {
            for (int col = 0; col < _numCol; col++)
            {
                Vector3 pos = new Vector3(col, line, 0);

                GameObject clone = Instantiate(_cellPrefab, pos, Quaternion.identity);
                m_Grid[col, line] = clone;
            }
        }
    }
    private void OnEnable()
    {

    }

    // Start is called before the first frame / Init con los otros componentes
    private void Start()
    {

    }

    // Update is called once per frame / Logica e Inputs
    private void Update()
    {

    }

    private void FixedUpdate()
    {

    }
    private void OnDisable()
    {

    }
    private void OnDestroy()
    {

    }
    
}
