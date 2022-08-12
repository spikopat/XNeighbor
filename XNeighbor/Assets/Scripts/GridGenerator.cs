using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    [Header("Grid boyutu. N x N")]
    [SerializeField, Range(2, 10)] private int gridSize = 2;
    [SerializeField] private GridLayoutGroup gridLayout;
    [SerializeField] private GameObject gridItemObject;

    private Vector2 screenSize
    {
        get
        {
            return new Vector2(Screen.width, Screen.height);
        }
    }

    private void Start()
    {
        SetGridSettings();
        CreateGrid();
    }

    private void SetGridSettings()
    {
        float _areaAmountPerGridItem = screenSize.x / gridSize;

        gridLayout.cellSize = new Vector2(_areaAmountPerGridItem * 0.9f, _areaAmountPerGridItem * 0.9f);
        gridLayout.spacing = new Vector2(_areaAmountPerGridItem * 0.05f, _areaAmountPerGridItem * 0.05f);
        gridLayout.padding = new RectOffset(
            (int)(_areaAmountPerGridItem * 0.05f),
            (int)(_areaAmountPerGridItem * 0.05f),
            (int)(_areaAmountPerGridItem * 0.1f),
            (int)(_areaAmountPerGridItem * 0.1f)
            );

    }

    private void CreateGrid()
    {
        for (int i = 0; i < gridSize ; i++)
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