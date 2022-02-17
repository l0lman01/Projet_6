using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private Slider _rowsSlider;
    [SerializeField] private Slider _colsSlider;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private TMP_Text _rowsText;
    [SerializeField] private TMP_Text _colsText;

    public DataManager dataManager;


    private void Start()
    {
        ChangeRows(_rowsSlider.value);
        ChangeCols(_colsSlider.value);
        ChangeSpeed(_speedSlider.value);
    }
    public async void SaveToJson()
    {
        await dataManager.SaveJsonData();
    }

    public async void LoadFromJson()
    {
        await dataManager.LoadJsonData();
    }
    public void ChangeRows(float value)
    {
        _rowsText.text = ((int) value).ToString();
    }
    public void ChangeCols(float value)
    {
        _colsText.text = ((int)value).ToString();
    }
    public void ChangeSpeed(float value)
    {
        _speedText.text = ((float)value).ToString("F1");
    }
}
