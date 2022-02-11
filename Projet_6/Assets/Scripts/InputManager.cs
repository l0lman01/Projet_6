using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]private Material _aliveMaterial;
    [SerializeField]private Material _deadMaterial;
    [SerializeField] private GridManager _gridManager;
    private void Awake()
    {
        //ancienne façon
        Object obj = FindObjectOfType(typeof(GridManager));
        _gridManager = (GridManager)obj;

        //valeur nullable
        _gridManager = obj as GridManager;

        _gridManager = FindObjectOfType<GridManager>();

        //Tous les composants
        FindObjectOfType<GridManager>();
    }

    private void ChangeCell(Cell cell)
    {
        var meshRenderer = cell.GetComponentInChildren<MeshRenderer>();

        if (cell.m_isAlive)
        {
            Debug.Log("alive");
            cell.m_isAlive = false;
            meshRenderer.sharedMaterial = _deadMaterial;

        }
        else
        {
            Debug.Log("dead");
            meshRenderer.sharedMaterial = _aliveMaterial;
            cell.m_isAlive = true;

        }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePosition = Input.mousePosition;
            Camera mainCamera = Camera.main;
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            var col = (int)mouseWorldPosition.x;
            var row = Mathf.FloorToInt(mouseWorldPosition.y);

            //col = Mathf.FloorToInt(mouseWorldPosition.x);

            if (col >= 0 && col < GridManager.Instance.m_NumCol &&
                row >= 0 && row < GridManager.Instance.m_NumRows)
            {
                var cell = GridManager.Instance.m_Grid[col, row];

                //var cellGO = GetComponent<Cell>();
                //var meshRenderer = cellGO.GetComponentInChildren<MeshRenderer>();
                Debug.Log($"{col} / {row}");
                ChangeCell(cell);
            }
        }
    }
    //private void Update()
    //{        
    //    if (Input.GetMouseButtonDown(0)) 
    //    {
    //        Vector3 mousePosition = Input.mousePosition;
    //        Camera mainCamera = Camera.main ;
    //        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
    //        Debug.Log($"Left click on: {mouseWorldPosition}");
    //        var col = Mathf.FloorToInt(mouseWorldPosition.x);
    //        var row = Mathf.FloorToInt(mouseWorldPosition.y);
    //        Debug.Log($"Left click on: {mouseWorldPosition.x}/{mouseWorldPosition.y}");

    //        if(col>= 0&& col< GridManager.Instance.m_NumCol&&
    //            row>= 0 && row < GridManager.Instance.m_NumRows)
    //        {
    //            var cell = GridManager.Instance.m_Grid[col, row];
    //           // var cell = cellGo.GetComponent<Cell>()
    //            var meshRenderer = cell.GetComponentInChildren<MeshRenderer>();
    //            if (meshRenderer.sharedMaterial == _aliveMaterial)
    //            {
    //                meshRenderer.sharedMaterial = _deadMaterial;
    //            }
    //            else if (meshRenderer.sharedMaterial == _deadMaterial)
    //            {
    //                meshRenderer.sharedMaterial = _aliveMaterial;
    //            }
    //        }
    //    }
    //}
}
