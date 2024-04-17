using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    public int numOfArmies;
    
    private void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        //num = Random.Range(1, 4);
        // Change the text on the text component.
        m_TextComponent.text = numOfArmies.ToString(); 
    }
}
