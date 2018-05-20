using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10.0f;
    public float jumpHeight = 14.0f;
    public Transform groundcheck;
    public Transform groundcheckFront;

    private float horizentalDirection;
    private bool grounded;
    private AudioSource myAudioSource;
    private Rigidbody2D rgdb2d;
    private Animator anim;
    private float scale;
    private bool dashing = false;



    void Start()
    {
        rgdb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scale = transform.localScale.x;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dashing)
        {
            horizentalDirection = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(horizentalDirection, 0, 0) * speed * Time.deltaTime, Camera.main.transform);
        }
        anim.SetFloat("vSpeed", rgdb2d.velocity.y);
        grounded = Physics2D.OverlapPoint(groundcheck.position) || Physics2D.OverlapPoint(groundcheckFront.position);
        anim.SetBool("grounded", grounded);
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            rgdb2d.velocity += new Vector2(rgdb2d.velocity.x, jumpHeight);

            if (Input.GetKeyDown(KeyCode.Space) && !dashing)
            {
                StartCoroutine(dash());
            }

        }
        
        if (horizentalDirection > 0)
        {
            anim.SetFloat("speed", 1);
          
                flip(scale);
        }
        else if (horizentalDirection < 0)
        {
            anim.SetFloat("speed", 1);
            
                flip(-scale);
            
        }
        else
        {
            anim.SetFloat("speed", 0);
        }
    }

    private void flip(float i)
    {
        Vector3 myScale = transform.localScale;
        myScale.x = i;
        transform.localScale = myScale;
    }

    private IEnumerator dash()
    {
        dashing = true;
        float startSpeed = speed;
        speed = 0;

        anim.SetBool("dashing", true);
        yield return new WaitForSeconds(0.7f);
        rgdb2d.velocity += new Vector2(rgdb2d.velocity.x, 4);
        if (transform.localScale.x<0)
        rgdb2d.AddForce(new Vector2(1, 0) * 2500);
        else
            rgdb2d.AddForce(new Vector2(-1, 0) * 2500);
        anim.SetBool("dashing", false);
        yield return new WaitUntil(() => !Physics2D.OverlapPoint(groundcheck.position));
        yield return new WaitUntil(() => Physics2D.OverlapPoint(groundcheck.position));
        speed = startSpeed;
        dashing = false;
    }
}

