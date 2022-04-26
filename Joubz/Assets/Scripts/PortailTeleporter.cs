using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortailTeleporter : MonoBehaviour
{
    public Transform player, reciever;

    private bool playerIsOverlapping;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset + transform.up;

                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Camera").GetComponent<CamFollow>().posLerpSpeed = 10000;
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Camera").GetComponent<CamFollow>().posLerpSpeed = 6;
            playerIsOverlapping = false;
        }
    }
}
