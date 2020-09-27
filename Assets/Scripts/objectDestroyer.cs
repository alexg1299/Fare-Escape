using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDestroyer : MonoBehaviour
{
    [SerializeField] private float distanceThreshold = 100;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > distanceThreshold)
            Destroy(gameObject);
    }
}
