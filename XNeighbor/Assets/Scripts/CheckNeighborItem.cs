using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNeighborItem : MonoBehaviour
{
    public bool IsLeftIndexExists(int xIndex)
    {
        return xIndex >= 1;
    }

    public bool IsRightIndexExists(int xIndex, List<List<GridItem>> GridItemsList)
    {
        return GridItemsList[0].Count - 1 > xIndex;
    }

    public bool IsTopIndexExists(int yIndex)
    {
        return yIndex >= 1;
    }

    public bool IsBottomIndexExists(int yIndex, List<List<GridItem>> GridItemsList)
    {
        return GridItemsList[0].Count - 1 > yIndex;
    }
}