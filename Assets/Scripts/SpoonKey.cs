using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonKey : MonoBehaviour {

    public GameObject jelly;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            jelly.gameObject.SetActive(false);
        }
    }
}
