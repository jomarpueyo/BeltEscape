using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetFloat("Highscore", 0).ToString("0.0");
	}
}
