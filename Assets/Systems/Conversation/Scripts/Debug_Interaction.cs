using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Interaction : MonoBehaviour {

    public CurrentEvent ce;
    public ParseText pt;
	// Use this for initialization
	void Start () {
        pt.LoadText();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("Can continue : " + ce.ParseEvent());
        }
    }
}
