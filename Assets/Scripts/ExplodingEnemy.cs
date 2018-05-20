using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : MonoBehaviour {

    public float speed = 7f;

    private Rigidbody2D rb2d;
    public Transform frontCheck;
    public Transform player;
    public GameObject explosion;
    private bool grounded = false;
    private float jumpTimer = 0f;
    private bool playerIsNear = false;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (playerIsNear) {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void Flip () {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        speed = -speed;
    }

    private void Explode () {
        Instantiate(explosion);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            //Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerIsNear = true;
        }
    }
}
