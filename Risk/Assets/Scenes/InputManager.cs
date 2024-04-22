using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InputManager : MonoBehaviour
{   
    public UnityEngine.UI.Button startButton;
    public TMP_Dropdown playerPicker;
    private int currPlayers;
    // Start is called before the first frame update
    void Start()
    {       
        startButton.onClick.AddListener(()=>PressedFunction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int SetDropdownValue()
    {
        int selectedIndex = playerPicker.value;
        currPlayers = selectedIndex + 2;
        return currPlayers;
    }

    private void PressedFunction(){
        Debug.Log("Button Pressed");
        SetDropdownValue();
        Debug.Log("Current Players: "+currPlayers);
        //GetDropDownValue()
        //RunGame(PlayerCount)
    }
}
