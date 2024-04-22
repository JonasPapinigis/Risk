using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{   
    public Button startButton;
    public Dropdown playerPicker;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() => GetDropdownValue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetDropdownValue()
    {
        int selectedIndex = playerPicker.value;
        string selectedText = playerPicker.options[selectedIndex].text;
        Debug.Log("Selected Index: " + selectedIndex + ", Selected Text: " + selectedText);
        return selectedIndex;
    }
}
