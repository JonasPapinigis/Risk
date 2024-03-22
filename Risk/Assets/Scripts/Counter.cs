using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TextUpdater: MonoBehaviour
{
  public TMP_Text messageText;

  void Start() // Or other method
  {
    messageText.SetText("3");
  }
}