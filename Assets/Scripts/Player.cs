using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10.0f;
    public float jumpHeight = 14.0f;
    public Transform groundcheck;

    private float horizentalDirection;
    private bool grounded;
    private AudioSource myAudioSource;
    private Rigidbody2D rgdb2d;
    private Animator anim;



    void Start()
    {
        rgdb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizentalDirection = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizentalDirection, 0, 0) * speed * Time.deltaTime, Camera.main.transform);

        grounded = Physics2D.OverlapPoint(groundcheck.position);

        if (grounded && Input.GetKeyDown(KeyCode.W))
        {
            rgdb2d.velocity += new Vector2(rgdb2d.velocity.x, jumpHeight);

        }

        if (horizentalDirection > 0)
        {
            Flip(-1);
            anim.SetFloat("speed", 1);
        }
        else if (horizentalDirection < 0)
        {
            Flip(1);
            anim.SetFloat("speed", 1);
        }
        else
        {
            anim.SetFloat("speed", 0);
        }
    }

    private void Flip(int facingRight)
    {
        Vector3 myScale = transform.localScale;
        myScale.x = facingRight;
        transform.localScale = myScale;
    }
}

