using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textValue : MonoBehaviour
{
    public Text textObj;

    private void Start()
    {
        textObj = GetComponent<Text>();
    }

    public void textUpdate(float value)
    {
        textObj.text = value.ToString();
    }
}
