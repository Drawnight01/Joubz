using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Transform respawnPoint, player;

    void Start ()
    {
        player = GameObject.Find("Player").transform;
        respawnPoint = transform.GetChild(0);
    }
    void OnTriggerEnter (Collider collider)
    {
        if(collider.tag == "Player")
        {
            player.position = respawnPoint.position;
            player.rotation = Quaternion.identity;
        }
    }
}
