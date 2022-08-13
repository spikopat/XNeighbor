using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSettings : MonoBehaviour
{
    [SerializeField] Canvas MainCanvas;
    private Vector2 screenSize
    {
        get
        {
            return new Vector2(Screen.width, Screen.height);
        }
    }

    public void SetGridSettings(GridLayoutGroup gridLayoutGroup, int gridSize)
    {
        float _areaAmountPerGridItem = 0;
        float gridItemSizeMultiplier = 0;
        if (IsScreenPortrait())
        {
            _areaAmountPerGridItem = screenSize.x / gridSize;
            gridItemSizeMultiplier = 0.9f;
        } else
        {
            _areaAmountPerGridItem = screenSize.y / gridSize;
            gridItemSizeMultiplier = 0.75f;
        }

        gridLayoutGroup.cellSize = new Vector2(_areaAmountPerGridItem * gridItemSizeMultiplier / MainCanvas.transform.localScale.x, _areaAmountPerGridItem * gridItemSizeMultiplier / MainCanvas.transform.localScale.y);
        gridLayoutGroup.spacing = new Vector2(_areaAmountPerGridItem * 0.05f / MainCanvas.transform.localScale.x, _areaAmountPerGridItem * 0.05f / MainCanvas.transform.localScale.y);
        gridLayoutGroup.padding = new RectOffset(
            (int)(_areaAmountPerGridItem * 0.05f),
            (int)(_areaAmountPerGridItem * 0.05f),
            (int)(_areaAmountPerGridItem * 0.25f),
            (int)(_areaAmountPerGridItem * 0.25f)
        );

        gridLayoutGroup.constraintCount = gridSize;
    }

    private bool IsScreenPortrait()
    {
        return screenSize.x <= screenSize.y;
    }
}