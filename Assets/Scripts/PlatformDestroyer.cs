using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    [SerializeField] private float distanceThreshold = 100;
    [SerializeField] private bool isStepped = false;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //if platform is stepped on and is a distance 
        //away from the player, destroy the platform
        if (isStepped && Vector3.Distance(player.transform.position, transform.position) > distanceThreshold)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if the player steps on the platform.
        if (collision.gameObject == player)
            isStepped = true;
    }
}
