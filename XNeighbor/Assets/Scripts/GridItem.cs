using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    public struct IndexStruct
    {
        public int XIndex;
        public int YIndex;

        public void SetIndexes(int xValue, int yValue)
        {
            XIndex = xValue;
            YIndex = yValue;
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

    private void Start()
    {


    }

    //Called by button
    public void OnClickGridItem()
    {
        GridItemUI.ToggleXText(true);
        GridController.Instance.GetClickedGridItemCoordinates(Indexes.GetXIndex(), Indexes.GetYIndex());
    }

    public void SetGridItemIndexes(int xIndex, int yIndex)
    {
        Indexes.SetIndexes(xIndex, yIndex);
    }

}