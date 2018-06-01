using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantityChanger : MonoBehaviour {
    private Text txtRef;

     int quantity;
    // Use this for initialization
    void Start () {
        txtRef = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        txtRef.text = quantity+"";
    }

   public void incrementQuantity()
    {
        quantity ++;
    }
}
