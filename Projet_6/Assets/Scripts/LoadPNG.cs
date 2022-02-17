using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadPNG : MonoBehaviour
{
    public void LoadImage()
    {
        Texture2D tex = null;
        byte[] fileData;

        Debug.Log(Application.dataPath + "/SavedImage/0.png");
        if (File.Exists(Application.dataPath + "/SavedImage/0.png"))
        {
            fileData = File.ReadAllBytes(Application.dataPath + "/SavedImage/0.png");
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);

            Debug.Log("sah");

            if (GridManager.Instance.m_Grid != null)
            {
                foreach (var cell in GridManager.Instance.m_Grid)
                {
                    Destroy(cell.gameObject);
                }
            }

            GridManager.Instance.m_Grid = new Cell[tex.width/50, tex.height/50];

            for (int row = 0; row < tex.height/50; row++)
            {
                for (int col = 0; col < tex.width/50; col++)
                {
                    Vector3 pos = new Vector3(col, row, 0);
                    Cell clone = Instantiate(GridManager.Instance._cellPrefab, pos, Quaternion.identity);
                    clone.name = $"[{row},{col}]";
                    clone.GetComponent<Cell>().m_isAlive = tex.GetPixel(col*50, row*50) == Color.white ? true : false;
                    GridManager.Instance.m_Grid[col, row] = clone;
                }
            }
        }
    }
}