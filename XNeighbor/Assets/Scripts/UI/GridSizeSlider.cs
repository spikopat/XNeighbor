using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridSizeSlider : MonoBehaviour
{
    [SerializeField] private Slider SizeSlider;
    [SerializeField] private TextMeshProUGUI GridSizeText;

    public void OnChangeSliderValue()
    {
        GridSizeText.text = SizeSlider.value + "X" + SizeSlider.value;
    }

}