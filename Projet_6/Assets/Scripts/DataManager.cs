using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class DataManager : MonoBehaviour
{    
    private string _name = "grid";

    private string getArrayData()
    {
        Grid gridData = new Grid();
        gridData._name = _name;
        gridData.m_col = GridManager.Instance.m_NumCol;
        gridData.m_rows = GridManager.Instance.m_NumRows;
        gridData.m_cells = new string[gridData.m_col * gridData.m_rows];

        int indexTracker = 0;

        for (int i = 0; i < gridData.m_col; i++)
        {
            for (int j = 0; j < gridData.m_rows; j++)
            {
                gridData.m_cells[indexTracker] = GridManager.Instance.m_Grid[i, j].m_isAlive.ToString();
                indexTracker++;

                Debug.Log($"{indexTracker}");
            }
        }

        return JsonUtility.ToJson(gridData);
    }

    public async Task SaveJsonData()
    {

        string gridInJson = getArrayData();
        string filepath = Application.persistentDataPath + "/Grids";


        byte[] encodedGrid = Encoding.UTF8.GetBytes(gridInJson);

        DirectoryInfo info = new DirectoryInfo(filepath);

        if (!info.Exists)
        {
            info.Create();
        }

        string path = Path.Combine(filepath, $"{_name}.json");

        using (FileStream SourceStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
        {
            await SourceStream.WriteAsync(encodedGrid, 0, encodedGrid.Length);
        }
        Debug.Log($"Saving Done in {filepath}");
    }

    public async Task LoadJsonData()
    {
        string filepath = Application.persistentDataPath + "/Grids";
        string fullFilepath = filepath + "/grid.json";


        using var sourceStream = new FileStream(fullFilepath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
        var sb = new StringBuilder();
        byte[] buffer = new byte[0x1000];
        int numRead;

        while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
        {
            string text = Encoding.UTF8.GetString(buffer, 0, numRead);
            sb.Append(text);
        }

        Grid grid = JsonUtility.FromJson<Grid>(sb.ToString());

        GridManager.Instance.ChangeCols(grid.m_col);
        GridManager.Instance.ChangeRows(grid.m_rows);
        GridManager.Instance.GenerateGrid();

        int indexTracker = 0;
        for (int i = 0; i < grid.m_col; i++)
        {
            for (int j = 0; j < grid.m_rows; j++)
            {
                GridManager.Instance.m_Grid[i, j].m_isAlive = System.Convert.ToBoolean(grid.m_cells[indexTracker]);
                Debug.Log(GridManager.Instance.m_Grid[i, j].m_isAlive);
                indexTracker++;
            }
        }

        Debug.Log("Json save successfully loaded !");
    }

    public class Grid
    {
        public string _name;
        public int m_rows;
        public int m_col;
        public string[] m_cells;

    }

}