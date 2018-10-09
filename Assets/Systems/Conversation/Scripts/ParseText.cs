using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParseText : MonoBehaviour {

    public TextAsset text;
    public CurrentEvent evnt;

    private void Start()
    {
        //LoadText();
    }

    public void LoadText()
    {
        string eachline = "";
        evnt.events.Clear();
        for(int i=0;i < text.text.Length; i++)
        {
            eachline += text.text[i];
            if (text.text[i] == '\n' || i == (text.text.Length - 1))
            {
                evnt.events.Add(eachline);
                eachline = "";
            }
        }
    }
}
