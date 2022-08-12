using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController Instance;
    public List<List<GridItem>> GridItemsList = new List<List<GridItem>>();
    private List<GridItem> tempList = new List<GridItem>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {


    }
    
    public void GetClickedGridItemCoordinates(int xIndex, int yIndex)
    {
        Debug.Log(GridItemsList[xIndex][yIndex], gameObject);
    }

    public void CheckAndAddGridItemsToList(GridItem gridItem)
    {
        if (!tempList.Contains(gridItem))
            tempList.Add(gridItem);
    }

}