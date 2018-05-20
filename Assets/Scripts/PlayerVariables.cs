using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVariables : MonoBehaviour
{

    public Transform startPosition;
    //Den som säger vad den nya spawn pointen är
    public float damageTimer;
    private AudioSource myAudioSource;
    public int life;

    public bool weaponCheck = true;
    void Start()
    {
        life = 9;
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GameController.gameControllerInstance.life = life;
    }

    public void Harm(float dmg)
    {
        if (damageTimer > 1.0f)
        {
            damageTimer = 0;
        }
    }

    public void Respawn()
    {
        Debug.Log("Respawn");
        life--;
        transform.position = startPosition.position;
        if (GameController.gameControllerInstance.life <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}