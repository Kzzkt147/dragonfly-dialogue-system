using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Button : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color unselectedColor;

    [SerializeField] private TextMeshProUGUI buttonText;
    
    private Image _buttonImage;

    public void SelectButton(bool selected)
    {
        _buttonImage.color = selected ? selectedColor : unselectedColor;
    }

    public void UpdateButtonText(string newText)
    {
        buttonText.text = newText;
    }

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }
}
