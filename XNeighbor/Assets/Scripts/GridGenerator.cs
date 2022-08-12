using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    public GridSettings GridSettings;

    [Header("Grid boyutu. N x N")]
    [SerializeField, Range(2, 10)] private int gridSize = 2;
    [SerializeField] private GridLayoutGroup gridLayout;
    [SerializeField] private GameObject gridItemObject;

    private void Start()
    {
        GridSettings.SetGridSettings(gridLayout, gridSize);
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            List<GridItem> items = new List<GridItem>();
            for (int j = 0; j < gridSize; j++)
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