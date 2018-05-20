using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePowerUp : MonoBehaviour {

    public int life = 1;
    public GameObject player;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerVariables>().life += 1;
        }
    }
}
