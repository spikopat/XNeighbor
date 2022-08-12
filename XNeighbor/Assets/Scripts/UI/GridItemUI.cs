using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridItemUI : MonoBehaviour
{
    public TextMeshProUGUI GridItemText;

    public void ToggleXText(bool value)
    {
        GridItemText.gameObject.SetActive(value);
    }

}