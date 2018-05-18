using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    bool timer = true;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!timer)
            return;

        timer = false;
        Invoke("ResetTimer", 1f);

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerVariables>().Respawn();
        }
        else
        {
            other.gameObject.SetActive(false);
        }
    }

    void ResetTimer()
    {
        timer = true;
    }
}