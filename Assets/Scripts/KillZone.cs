﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerVariables>().Respawn();
        }
        else
        {
            if (!other.gameObject.CompareTag("Enemy")){
                other.gameObject.SetActive(false);
            }
        }
    }
}