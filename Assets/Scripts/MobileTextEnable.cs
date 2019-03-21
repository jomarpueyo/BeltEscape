using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileTextEnable : MonoBehaviour {

    Text thisText;
    GameManager gm;
    public string insertText;

	// Use this for initialization
	void Start () {
        thisText = GetComponent<Text>();
        gm = GameManager.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gm.gameEnded && gm.isMobile)
        {
            thisText.text = insertText;
        }
	}
}
