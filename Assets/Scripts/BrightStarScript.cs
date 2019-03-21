using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BrightStarScript : MonoBehaviour {

    Animator m_Animator;

	// Use this for initialization
	void Start () {
        m_Animator = GetComponent<Animator>();
        m_Animator.Update(Random.value);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
