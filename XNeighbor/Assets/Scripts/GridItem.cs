using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GridItem : MonoBehaviour
{
    public struct IndexStruct
    {
        public int YIndex;
        public int XIndex;

        public void SetIndexes(int yValue, int xValue)
        {
            YIndex = yValue;
            XIndex = xValue;
        }

        public int GetXIndex()
        {
            return XIndex;
        }

        public int GetYIndex()
        {
            return YIndex;
        }
    }

    [HideInInspector] public IndexStruct Indexes;
    [SerializeField] public GridItemUI GridItemUI;
    [SerializeField] private bool isSelected;

    private void Start()
    {


    }

    //Called by button
    public void OnClickGridItem()
    {
        isSelected = true;
        GridItemUI.ToggleXText(true);

        GridController.Instance.ExecuteClickedGridItem(Indexes.GetYIndex(), Indexes.GetXIndex());
    }

    public void SetGridItemIndexes(int yIndex, int xIndex)
    {
        Indexes.SetIndexes(yIndex, xIndex);
    }

    public void ReleaseGridItem()
    {
        GridItemUI.ToggleXText(false);
        isSelected = false;
    }

    public bool IsSelected()
    {
        return isSelected;
    }

}