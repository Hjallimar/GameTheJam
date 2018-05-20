using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : MonoBehaviour {

    public float speed = 7f;

    private bool facingRight = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    public Transform player;
    private bool grounded = false;
    private float jumpTimer = 0f;
    private bool playerIsNear = false;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (playerIsNear) {
            anim.SetBool("Aggro", true);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (facingRight && player.position.x - transform.position.x > 0) {
                FlipLeft();
            }
            if(!facingRight && player.position.x - transform.position.x < 0) {
                FlipRight();
            }
        }
    }

    private void FlipLeft () {
        facingRight = false;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void FlipRight () {
        facingRight = true;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerIsNear = true;
        }
    }
}
