using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {
    private Text txtRef;
    public static string obiectLovit;
    public static bool textDisplaying=false;
    private void Awake()
    {
        txtRef = GetComponent<Text>();//or provide from somewhere else (e.g. if you want via find GameObject.Find("CountText").GetComponent<Text>();)
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        txtRef.text = "";
        if (textDisplaying)
            txtRef.text = obiectLovit;
        textDisplaying = false;


    }
}
