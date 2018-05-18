using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVariables : MonoBehaviour
{

    public Transform startPosition;
    //Den som säger vad den nya spawn pointen är
    public float damageTimer;
    public float health = 100;
    private AudioSource myAudioSource;
    public int life;

    public bool weaponCheck = true;
    void Start()
    {
        health = 100;
        life = 3;
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        damageTimer += Time.deltaTime;
        //GameController.gameControllerInstance.playerHealth = health;
    }

    public void Harm(float dmg)
    {
        if (damageTimer > 1.0f)
        {
            health -= dmg;
            damageTimer = 0;
            //GameController.gameControllerInstance.ScreenShake();
        }

        if (health < 1)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        Debug.Log("Respawn");
        //GameController.gameControllerInstance.life -= 1;
        transform.position = startPosition.position;
        health = 100;
       /* if (GameController.gameControllerInstance.life <= 0)
        {
            SceneManager.LoadScene(0);
        }*/
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            //GameController.gameControllerInstance.coins += 1;
        }
    }
}