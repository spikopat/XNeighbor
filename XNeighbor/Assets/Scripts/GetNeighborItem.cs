using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNeighborItem : MonoBehaviour
{
    public GridItem GetBottomNeighborGridItem(List<List<GridItem>> GridItemsList, int yIndex, int xIndex)
    {
        return GridItemsList[yIndex + 1][xIndex];
    }

    public GridItem GetTopNeighborGridItem(List<List<GridItem>> GridItemsList, int yIndex, int xIndex)
    {
        return GridItemsList[yIndex - 1][xIndex];
    }

    public GridItem GetRightNeighborGridItem(List<List<GridItem>> GridItemsList, int yIndex, int xIndex)
    {
        return GridItemsList[yIndex][xIndex + 1];
    }

    public GridItem GetLeftNeighborGridItem(List<List<GridItem>> GridItemsList, int yIndex, int xIndex)
    {
        return GridItemsList[yIndex][xIndex - 1];
    }
}