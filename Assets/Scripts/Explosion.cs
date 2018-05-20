using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float expansionSpeed = 10f;
    public float lifeTime = 0.5f;

    private float timer = 0f;

    void Start () {

    }

    void Update () {
        if(transform.localScale.x < 0.5f) {
            transform.localScale += new Vector3(Time.deltaTime * expansionSpeed, Time.deltaTime * expansionSpeed);
        }
        
        if (timer > lifeTime) {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }
}
