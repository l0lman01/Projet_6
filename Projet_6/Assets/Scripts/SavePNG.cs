using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavePNG : MonoBehaviour
{
    public int CellSize = 50;
    [SerializeField] GridManager _gridManager;

    public void SaveImage(){

        Object obj = FindObjectOfType(typeof(GridManager));
        _gridManager = (GridManager)obj;
        _gridManager = obj as GridManager;
        _gridManager = FindObjectOfType<GridManager>();
        FindObjectOfType<GridManager>();

        // Create a texture the size of the screen, RGB24 format
        int width = GridManager.Instance.m_Grid.GetLength(0)* CellSize;
        int height = GridManager.Instance.m_Grid.GetLength(1) * CellSize;

        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);


        // Read screen contents into the texture
        //tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        for (int i = 0; i < GridManager.Instance.m_Grid.GetLength(0); i++)
        {
            for (int j = 0; j < GridManager.Instance.m_Grid.GetLength(1); j++)
            {
                for (int x = 0; x < CellSize; x++)
                {
                    for (int y = 0; y < CellSize; y++)
                    {
                        Color cellColor = GridManager.Instance.m_Grid[i, j].GetComponent<Cell>().m_isAlive ? Color.white : Color.black;
                        tex.SetPixel((i * CellSize) + x, (j * CellSize) + y, cellColor);
                    }
                }
            }
        }
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        var path = Application.dataPath + "/SavedImage/";
        if (!Directory.Exists(path)){
            Directory.CreateDirectory(path);
        }
        File.WriteAllBytes(path + "0.png", bytes);
    }
}