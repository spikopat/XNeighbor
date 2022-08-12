using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridItem : MonoBehaviour
{

    public TextMeshProUGUI GridItemText;

    private void Start()
    {


    }

    public void ToggleXText(bool value)
    {
        GridItemText.gameObject.SetActive(value);
    }

}