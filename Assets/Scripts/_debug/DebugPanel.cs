using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "init";
    }

    public void changeTextTo(string newText)
    {
        text.text = newText;
    }
}