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
        _gridManager = FindObjectOfType<GridManager>();
        Debug.Log(_gridManager.GetComponent<GameObject>());
    }
    private void Update()
    {        
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePosition = Input.mousePosition;
            Camera mainCamera = Camera.main ;
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            Debug.Log($"Left click on: {mouseWorldPosition}");
            var col = Mathf.FloorToInt(mouseWorldPosition.x);
            var row = Mathf.FloorToInt(mouseWorldPosition.y);
            Debug.Log($"Left click on: {mouseWorldPosition.x}/{mouseWorldPosition.y}");

            if(col>= 0&& col< GridManager.Instance.m_NumCol&&
                row>= 0 && row < GridManager.Instance.m_NumLines)
            {
                var cell = GridManager.Instance.m_Grid[col, row];
               // var cell = cellGo.GetComponent<Cell>()
                var meshRenderer = cell.GetComponentInChildren<MeshRenderer>();
                if (meshRenderer.sharedMaterial == _aliveMaterial)
                {
                    meshRenderer.sharedMaterial = _deadMaterial;
                }
                else if (meshRenderer.sharedMaterial == _deadMaterial)
                {
                    meshRenderer.sharedMaterial = _aliveMaterial;
                }
            }
        }
    }
}
