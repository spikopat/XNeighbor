using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController Instance;
    public List<List<GridItem>> GridItemsList = new List<List<GridItem>>();
    public List<GridItem> controlList = new List<GridItem>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {


    }

    public void ExecuteClickedGridItem(int yIndex, int xIndex)
    {
        controlList.Clear();

        //Tiklanan itemi listeye al.
        AddGridItemToControlList(GridItemsList[yIndex][xIndex]);

        //Tum secilmis itemler kontrol edilene kadar calis.
        TraverseAllSelectedNeighborPoints();

        //Birbirine komsu olan secilmis itemleri temizle.
        if (CheckReleaseCondition())
            ReleaseTempList();
    }

    private void TraverseAllSelectedNeighborPoints()
    {
        int i = 0;
        do
        {
            FindLeftNeighbor(controlList[i].Indexes.GetYIndex(), controlList[i].Indexes.GetXIndex());
            FindRightNeighbor(controlList[i].Indexes.GetYIndex(), controlList[i].Indexes.GetXIndex());
            FindTopNeighbor(controlList[i].Indexes.GetYIndex(), controlList[i].Indexes.GetXIndex());
            FindBottomNeighbor(controlList[i].Indexes.GetYIndex(), controlList[i].Indexes.GetXIndex());
            i++;
        } while (i < controlList.Count);
    }

    #region RecursiveNeighborFinder
    //Gonderilen itemin solundaki itemi kontrol et, item varsa ve secilmis ise listeye al.
    private void FindLeftNeighbor(int yIndex, int xIndex)
    {
        if (IsLeftIndexExists(xIndex) && GetLeftNeighborGridItem(yIndex, xIndex).IsSelected())
        {
            AddGridItemToControlList(GetLeftNeighborGridItem(yIndex, xIndex));
        }
    }

    //Gonderilen itemin sagindaki itemi kontrol et, item varsa ve secilmis ise listeye al.
    private void FindRightNeighbor(int yIndex, int xIndex)
    {
        if (IsRightIndexExists(xIndex) && GetRightNeighborGridItem(yIndex, xIndex).IsSelected())
        {
            AddGridItemToControlList(GetRightNeighborGridItem(yIndex, xIndex));
        }
    }

    //Gonderilen itemin uzerindeki itemi kontrol et, item varsa ve secilmis ise listeye al.
    private void FindTopNeighbor(int yIndex, int xIndex)
    {
        if (IsTopIndexExists(yIndex) && GetTopNeighborGridItem(yIndex, xIndex).IsSelected())
        {
            AddGridItemToControlList(GetTopNeighborGridItem(yIndex, xIndex));
        }
    }

    //Gonderilen itemin altindaki itemi kontrol et, item varsa ve secilmis ise listeye al.
    private void FindBottomNeighbor(int yIndex, int xIndex)
    {
        if (IsBottomIndexExists(yIndex) && GetBottomNeighborGridItem(yIndex, xIndex).IsSelected())
        {
            AddGridItemToControlList(GetBottomNeighborGridItem(yIndex, xIndex));
        }
    }
    #endregion

    #region CheckNeighborIndexes
    private bool IsLeftIndexExists(int xIndex)
    {
        return xIndex >= 1;
    }

    private bool IsRightIndexExists(int xIndex)
    {
        return GridItemsList[0].Count - 1 > xIndex;
    }

    public bool IsTopIndexExists(int yIndex)
    {
        return yIndex >= 1;
    }

    public bool IsBottomIndexExists(int yIndex)
    {
        return GridItemsList[0].Count - 1 > yIndex;
    }
    #endregion

    #region GetNeighborGridItem
    private GridItem GetRightNeighborGridItem(int yIndex, int xIndex)
    {
        return GridItemsList[yIndex][xIndex + 1];
    }

    private GridItem GetLeftNeighborGridItem(int yIndex, int xIndex)
    {
        return GridItemsList[yIndex][xIndex - 1];
    }

    private GridItem GetTopNeighborGridItem(int yIndex, int xIndex)
    {
        return GridItemsList[yIndex - 1][xIndex];
    }

    private GridItem GetBottomNeighborGridItem(int yIndex, int xIndex)
    {
        return GridItemsList[yIndex + 1][xIndex];
    }
    #endregion

    public void AddGridItemToControlList(GridItem gridItem)
    {
        if (!controlList.Contains(gridItem))
            controlList.Add(gridItem);
    }

    private bool CheckReleaseCondition()
    {
        return controlList.Count >= 3;
    }

    private void ReleaseTempList()
    {
        foreach (var item in controlList)
        {
            item.ReleaseGridItem();
        }
        controlList.Clear();
    }

}