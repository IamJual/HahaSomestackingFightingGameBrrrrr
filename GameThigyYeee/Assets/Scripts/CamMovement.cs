using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    
    public Transform player;
    public float lerpSpeed = 2f;    
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 playerPosition = player.position + offset;
        Vector3 lerpPosition = Vector3.Lerp(transform.position, playerPosition, lerpSpeed * Time.deltaTime);
        
        transform.position = lerpPosition;
        transform.LookAt(player);
    }
}
