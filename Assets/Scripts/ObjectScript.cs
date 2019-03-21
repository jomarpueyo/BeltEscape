using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

    float randHorizontal;                   //- or + (left or right)
    float horizontalForceApplied = 120f;    //Bigger is faster
    float gravityScaler          = 50f;     //Bigger is slower
    float lowerBoundsDestroy     = -7f;     //Bottom of screen destroy
    float spinIntensity          = 10f;     //Bigger is faster
    AudioManager audioM;

    void Start()
    {
        if (Random.value > .5f)
        {
            randHorizontal = -1f;
        }
        else
        {
            randHorizontal = 1f;
        }

        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / gravityScaler;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.value * randHorizontal*horizontalForceApplied,0));
        GetComponent<Rigidbody2D>().AddTorque((Random.value + 1) * spinIntensity);
    }

    // Update is called once per frame
    void Update () {
		if(transform.position.y < lowerBoundsDestroy)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("WallBump3");
        }

        if (col.gameObject.tag == "Asteroids")
        {
            FindObjectOfType<AudioManager>().Play("WallBump2");
        }
    }
}
