using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridItemUI : MonoBehaviour
{
    [SerializeField] private GridItemTextEffect GridItemTextEffect;

    public void ToggleXText(bool value)
    {
        if (value)
            GridItemTextEffect.gameObject.SetActive(true);
        else
            GridItemTextEffect.EndingSequence();
    }

}