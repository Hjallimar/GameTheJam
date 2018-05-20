using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour {

    public GameObject explosion;
    private bool exploded = false;

    private void Update () {

    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (!exploded) {
                Explode();
            }
        }
    }

    private void Explode () {
        Instantiate(explosion, transform.position, new Quaternion());
        exploded = true;
        Invoke("Destroy", 0f);
    }

    private void Destroy () {
        foreach (Transform transform in GetComponentsInParent<Transform>()) {
            Destroy(transform.gameObject);
        }
    }
}
