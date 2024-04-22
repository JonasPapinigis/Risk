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
    public static int pCount;
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
        pCount = selectedIndex + 2;
        return pCount;
    }

    private void PressedFunction(){
        Debug.Log("Button Pressed");
        SetDropdownValue();
        Debug.Log("Current Players: "+pCount);
        SceneManager.LoadScene("Map");
    }
}
