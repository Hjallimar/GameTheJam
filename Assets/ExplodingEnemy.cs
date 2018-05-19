﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : MonoBehaviour {

    public float speed = 7f;

    private Rigidbody2D rb2d;
    public Transform frontCheck;
    public Transform player;
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
            if (Physics2D.OverlapPoint(frontCheck.position) && Physics2D.OverlapPoint(frontCheck.position).CompareTag("Player")) {
                //Explode();
            }
        }
    }

    private void Flip () {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        speed = -speed;
    }

    private void Explode () {
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
