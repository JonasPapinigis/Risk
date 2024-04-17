using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TextUpdater: MonoBehaviour
{
  public TMP_Text messageText;
  public int num;
  num = Random.range(1, 3)
  void Update() // Or other method
  {
    messageText.SetText(num);
  }
}