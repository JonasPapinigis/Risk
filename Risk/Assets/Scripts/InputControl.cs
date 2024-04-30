using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InputControl : MonoBehaviour
{   
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button confirmButton;
    public UnityEngine.UI.Button nextPhaseButton;
    public TMP_InputField generalInputField;
    public TMP_Dropdown playerPicker;
    // Start is called before the first frame update
    void Start()
    {

        startButton.onClick.AddListener(()=>StartPressedFunction());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDropdownValue()
    {
        int selectedIndex = playerPicker.value;
        GameData.pCount = selectedIndex + 2;
    }

    private void StartPressedFunction(){
        Debug.Log("Button Pressed");
        SetDropdownValue();
        Debug.Log("Current Players: "+GameData.pCount);
        SceneManager.LoadScene("Map");
    }
}
