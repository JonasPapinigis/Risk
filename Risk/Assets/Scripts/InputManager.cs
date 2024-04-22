using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{   
    public Button startButton;
    public Dropdown playerPicker;
    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(GetDropdownValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetDropdownValue()
    {
        int selectedIndex = myDropdown.value;
        string selectedText = myDropdown.options[selectedIndex].text;
        Debug.Log("Selected Index: " + selectedIndex + ", Selected Text: " + selectedText);
    }
}
