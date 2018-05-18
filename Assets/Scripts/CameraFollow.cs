using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player1;
    public float smooth = 5.0f;
    public float offset = 1.0f;

    void LateUpdate()
    {

        Vector3 targetPosition = new Vector3(player1.position.x, player1.position.y + offset, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

    }
}
