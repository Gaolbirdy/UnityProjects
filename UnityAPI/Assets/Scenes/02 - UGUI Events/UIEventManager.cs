using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventManager : MonoBehaviour 
{
    public GameObject btnGameobject;
    public GameObject sliderGameobject;
    public GameObject dropdownGameobject;
    public GameObject toggleGameobject;

    private void Start()
    {
        btnGameobject.GetComponent<Button>().onClick.AddListener(this.ButtonOnClick);
        sliderGameobject.GetComponent<Slider>().onValueChanged.AddListener(this.OnSliderChanged);
        dropdownGameobject.GetComponent<Dropdown>().onValueChanged.AddListener(this.OnDropdownChanged);
        toggleGameobject.GetComponent<Toggle>().onValueChanged.AddListener(this.OnToggleChanged);
    }

    private void ButtonOnClick()
    {
        Debug.Log("ButtonOnClick");
    }

    private void OnSliderChanged(float value)
    {
        Debug.Log("SliderChangerd: " + value);
    }

    private void OnDropdownChanged(Int32 value)
    {
        Debug.Log("DropdownChanged: " + value);
    }

    private void OnToggleChanged(bool value)
    {
        Debug.Log("ToggleChanged: " + value);
    }
}
