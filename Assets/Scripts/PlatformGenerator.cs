using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject pepperPrefab;
    [SerializeField] private GameObject tacoPrefab;
    [SerializeField] private GameObject drinkPrefab;
    [SerializeField] private GameObject avocadoPrefab;
    [SerializeField] private GameObject copPrefab;
    private GameObject player;
    
    [SerializeField] private float distanceThreshold = 100;
    private Vector3 nextPlatformPos = Vector3.zero;

    [SerializeField] private GameController gameController;
    
    private void Awake()
    {
        if (!gameController)
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(platformPrefab, nextPlatformPos, Quaternion.identity);
        nextPlatformPos += new Vector3(0, 0, 55);

    }


    private void Update()
    {
        if (Vector3.Distance(player.transform.position, nextPlatformPos) < distanceThreshold)
        {
            Instantiate(platformPrefab, nextPlatformPos, Quaternion.identity);


            for (int i = Random.Range(0, 3); i < 2; i++)
            {
                //Create the pepper power up
                tacoPrefab.transform.position = new Vector3(Random.Range(-8, 9), 1, Random.Range(-21, 25));
                Instantiate(pepperPrefab, nextPlatformPos+ tacoPrefab.transform.position, Quaternion.identity);
            }

            //level 2+ generate these power ups/downs
            if (gameController.currLevel >=2)
            {
                for (int i = Random.Range(0, 2); i < 1; i++)
                {
                    tacoPrefab.transform.position = new Vector3(Random.Range(-8, 9), 1, Random.Range(-21, 25));
                    Instantiate(tacoPrefab, nextPlatformPos + tacoPrefab.transform.position, Quaternion.identity);
                }
                for (int i = Random.Range(0, 3); i < 1; i++)
                {
                    drinkPrefab.transform.position = new Vector3(Random.Range(-8, 9), 1, Random.Range(-21, 25));
                    Instantiate(drinkPrefab, nextPlatformPos+ drinkPrefab.transform.position, Quaternion.identity);
                }
            }

            //level 3+ generate these power up/down
            if(gameController.currLevel >= 3)
            {
                for (int i = Random.Range(0, 3); i < 1; i++)
                {
                    avocadoPrefab.transform.position = new Vector3(Random.Range(-8, 9), 1, Random.Range(-21, 25));

                    Instantiate(avocadoPrefab, nextPlatformPos + avocadoPrefab.transform.position, Quaternion.identity);
                }
                for (int i = Random.Range(0, 3); i < 1; i++)
                {
                    copPrefab.transform.position = new Vector3(Random.Range(-8, 9), 2, Random.Range(-21, 25));
                    copPrefab.transform.rotation = new Quaternion(0, 180, 0, 0);
                    Instantiate(copPrefab, nextPlatformPos + copPrefab.transform.position, copPrefab.transform.rotation);
                }
            }

            //for loop to instantiate multiple objects
            for (int i = 0; i < gameController.numObstacles; i++)
            {
                obstaclePrefab.transform.position = new Vector3(Random.Range(-8, 9), 1, Random.Range(-21, 25));
                Instantiate(obstaclePrefab, nextPlatformPos + obstaclePrefab.transform.position, Quaternion.identity);
            }
            
            //Get random position of the next platform to be generated
            nextPlatformPos += new Vector3(Random.Range(-6,7),Random.Range(-3,4) , Random.Range(54, 57));
        }
    }
}
