using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour {

    public float scrollSpeed = 0.15f;
    Vector3 currPos;

    void Update()
    {
        currPos = transform.position;
        transform.position = currPos + Vector3.down * scrollSpeed * Time.deltaTime;
    }
}

