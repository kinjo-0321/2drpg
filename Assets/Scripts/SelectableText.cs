using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableText : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void SetText(string newName)
    {
        if(text == null)
        {
            text = GetComponent<Text>();
        }
        text.text = newName;
    }

    public void SetSelectedColor(bool selected)
    {
        if(text == null)
        {
            text = GetComponent<Text>();
        }

        if(selected)
        {
            text.color = Color.yellow;
        }
        else
        {
            text.color = Color.white;
        }
    }
}
