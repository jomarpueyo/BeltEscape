using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueTip : MonoBehaviour {

    public Text tipText;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.FindObjectOfType<GameManager>();
        Debug.Log(gm.isPc);
    }

    // Update is called once per frame
    void Update () {
        if (gm.gameEnded && gm.isPc)
        {
            tipText.text = "Any Key to Restart\nESC to Menu";
        }
	}
}
