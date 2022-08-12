using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController Instance;

    public List<List<GridItem>> GridItemsList = new List<List<GridItem>>();

    [SerializeField] public List<GridItem> controlList = new List<GridItem>();

    [SerializeField] private CheckNeighborItem checkNeighborItem;
    [SerializeField] private GetNeighborItem getNeighborItem;

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
        ClearControlList();

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
            FindAndAddLeftNeighbor(controlList[i].Indexes.GetYIndex(), controlList[i].Indexes.GetXIndex());
            FindAndAddRightNeighbor(controlList[i].Indexes.GetYIndex(), controlList[i].Indexes.GetXIndex());
            FindAndAddTopNeighbor(controlList[i].Indexes.GetYIndex(), controlList[i].Indexes.GetXIndex());
            FindAndAddBottomNeighbor(controlList[i].Indexes.GetYIndex(), controlList[i].Indexes.GetXIndex());
            i++;
        } while (i < controlList.Count);
    }

    #region CreateControlList
    //Gonderilen itemin solundaki itemi kontrol et, item varsa ve secilmis ise listeye al.
    private void FindAndAddLeftNeighbor(int yIndex, int xIndex)
    {
        if (!checkNeighborItem.IsLeftIndexExists(xIndex))
            return;

        GridItem selectedGridItem = getNeighborItem.GetLeftNeighborGridItem(GridItemsList, yIndex, xIndex);
        if (selectedGridItem.IsSelected())
            AddGridItemToControlList(selectedGridItem);
    }

    //Gonderilen itemin sagindaki itemi kontrol et, item varsa ve secilmis ise listeye al.
    private void FindAndAddRightNeighbor(int yIndex, int xIndex)
    {
        if (!checkNeighborItem.IsRightIndexExists(xIndex, GridItemsList))
            return;

        GridItem selectedGridItem = getNeighborItem.GetRightNeighborGridItem(GridItemsList, yIndex, xIndex);
        if (selectedGridItem.IsSelected())
            AddGridItemToControlList(selectedGridItem);
    }

    //Gonderilen itemin uzerindeki itemi kontrol et, item varsa ve secilmis ise listeye al.
    private void FindAndAddTopNeighbor(int yIndex, int xIndex)
    {
        if (!checkNeighborItem.IsTopIndexExists(yIndex))
            return;

        GridItem selectedGridItem = getNeighborItem.GetTopNeighborGridItem(GridItemsList, yIndex, xIndex);
        if (selectedGridItem.IsSelected())
            AddGridItemToControlList(selectedGridItem);
    }

    //Gonderilen itemin altindaki itemi kontrol et, item varsa ve secilmis ise listeye al.
    private void FindAndAddBottomNeighbor(int yIndex, int xIndex)
    {
        if (!checkNeighborItem.IsBottomIndexExists(yIndex, GridItemsList))
            return;

        GridItem selectedGridItem = getNeighborItem.GetBottomNeighborGridItem(GridItemsList, yIndex, xIndex);
        if (selectedGridItem.IsSelected())
            AddGridItemToControlList(selectedGridItem);
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
            item.ReleaseGridItem();

        ClearControlList();
    }

    private void ClearControlList()
    {
        controlList.Clear();
    }

}