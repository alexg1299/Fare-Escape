using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //private float speed = 10f;
    //[SerializeField] private float jumpIntensity = 7f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private GameController gameController;
   
    // Start is called before the first frame update
    private void Start()
    {
        if (!gameController)
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 1) * Time.deltaTime * gameController.speed;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * gameController.jumpIntensity, ForceMode.Impulse);
           
        }
 
        //can also use s key to go down
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && !isGrounded)
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * gameController.jumpIntensity * 2, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.A))
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left);
        if (Input.GetKeyDown(KeyCode.D))
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right);

        if (Input.GetKeyDown(KeyCode.P))
        {
            gameController.PauseGame();
            gameController.gamePanel.SetActive(false);
            gameController.pausePanel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") 
            isGrounded = true;
        if(collision.gameObject.tag == "Net")
        {
            gameController.health -= 10;
            gameController.die();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Obstacle Hit!!");
            gameController.health -= 10;
        }
        
        if(other.gameObject.tag == "Pepper")
        {
            Debug.Log("Jump Higher!!");
            if(gameController.jumpIntensity <= 12)
                gameController.jumpIntensity += 5;
            Destroy(other.gameObject);
            
        }
        
        if(other.gameObject.tag == "Taco")
        {
            Debug.Log("Run Slower.");
            //get random int 
            float ranSpeed = 3;
            if((gameController.speed - ranSpeed) >= 5 )
                gameController.speed -= 3;
            Destroy(other.gameObject);
        }
        
        if(other.gameObject.tag == "Avocado")
        {
            Debug.Log("+20 health");
            if (gameController.health <= 80)
                gameController.health += 20;
            else
                gameController.health = 100;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Cop")
        {
            Debug.Log("-30 health");
            gameController.health -= 30;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Drink")
        {
            Debug.Log("Run faster");
            if(gameController.speed <= 23)
                gameController.speed += 7;
            Destroy(other.gameObject);
        }
    }
}
