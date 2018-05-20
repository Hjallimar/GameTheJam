using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 10f;
    public float timeUntilJump = 1f;
    public float jumpForce = 50f;

    private Rigidbody2D rb2d;
    public Transform frontCheck;
    public Transform groundCheck;
    private bool grounded = false;
    private float jumpTimer = 0f;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        grounded = Physics2D.OverlapPoint(groundCheck.position);
        //rb2d.AddForce(new Vector2(-speed, 0));
        if (Physics2D.OverlapPoint(frontCheck.position) && !Physics2D.OverlapPoint(frontCheck.position).CompareTag("Player") && !Physics2D.OverlapPoint(frontCheck.position).CompareTag("Enemy") && !Physics2D.OverlapPoint(frontCheck.position).CompareTag("Explosion")) {
            Flip();
        }
        if(jumpTimer >= timeUntilJump && grounded) {
            Jump();
            jumpTimer = 0;
        }
        jumpTimer += Time.deltaTime;
    }

    private void Flip () {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        speed = -speed;
    }

    private void Jump () {
        rb2d.AddForce(new Vector2(0, jumpForce));
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Wall")) {
            Flip();
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.collider.GetComponent<PlayerVariables>().Respawn();
            Destroy(this.gameObject);
        }
    }
}
