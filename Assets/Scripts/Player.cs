using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Game mechanics
    public float aiInput   = 0;
    float speed            = 30f;
    float mobileTouchSpeed = 15f;
    float mapWidth         = 3.0f;
    float tiltSensitivity  = 0.05f;
    float x;
    public Animator animator;
    private Rigidbody2D rb;
    GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameManager.FindObjectOfType<GameManager>();
    }
    
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (gm.isPc) x = pcControls();
        if (gm.isMobile) x = mobileTouchControls();
        if (gm.isMobileAccelerator) x = mobileAcceleratorControls();

        animator.SetFloat("Speed", x);
        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        FindObjectOfType<GameManager>().EndGame();
    }
    
    float TiltMovement()
    {
        float rawMove = Input.acceleration.x;
        if (rawMove > tiltSensitivity || rawMove < -tiltSensitivity) return Input.acceleration.x;
        else return 0f;
    }

    //Input should be a value of -1 to 1
    float aiControls(float input)
    {
        return input * Time.fixedDeltaTime * speed;
    }

    float inp2fit(float [] inps)
    {
        float ret = 0;
        for(int i = 0; i < inps.Length; i++)
        {
            ret += inps[i];
        }
        return ((ret / inps.Length) / 100);
    }

    float pcControls()
    {
        return Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
    }

    float mobileAcceleratorControls()
    {
        return TiltMovement() * Time.fixedDeltaTime * speed;
    }

    float mobileTouchControls()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.position.x < Screen.width / 2) //Left
        {
            x = -1.0f * Time.fixedDeltaTime * mobileTouchSpeed;
        }
        if (touch.position.x > Screen.width / 2) //Right
        {
            x = 1.0f * Time.fixedDeltaTime * mobileTouchSpeed;
        }

        return x;
    }
}
