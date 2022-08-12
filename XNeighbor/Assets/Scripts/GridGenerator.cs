using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    public GridSettings GridSettings;
    public Slider GridSizeSlider;

    [SerializeField] private GridLayoutGroup gridLayout;
    [SerializeField] private GameObject gridItemObject;

    private void Start()
    {
        
    }

    //Called by button
    public void OnClickGenerateButton()
    {
        SetGridSettings();
        CreateGrid();
    }

    private void SetGridSettings()
    {
        GridSettings.SetGridSettings(gridLayout, (int)GridSizeSlider.value);
    }

    private void CreateGrid()
    {
        for (int i = 0; i < (int)GridSizeSlider.value; i++)
        {
            List<GridItem> items = new List<GridItem>();
            for (int j = 0; j < (int)GridSizeSlider.value; j++)
            {
                GridItem gridItem = Instantiate(gridItemObject, gridLayout.transform).GetComponent<GridItem>();
                gridItem.gameObject.name += "[" + i + "]" + "[" + j + "]";
                gridItem.SetGridItemIndexes(i, j);
                items.Add(gridItem);
            }
            GridController.Instance.GridItemsList.Add(items);
        }
    }

}