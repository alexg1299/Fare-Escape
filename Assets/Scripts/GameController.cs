using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int health = 100;
    public int healthStart = 100;
    public int timer = 30;
    public int currLevel = 0;
    public int numObstacles = 1;
    public float speed = 8f;
    public float speedStart = 8f;
    public float jumpIntensity = 7f;
    public string isPlaying = "false";
    public bool isPaused = false;

    public Text LevelText;
    public Text TimerText;
    public Text HealthBarText;

    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject congratsPanel;
    [SerializeField] public GameObject gamePanel;
    [SerializeField] public GameObject pausePanel;
    [SerializeField] private GameObject mainMenuPanel;

    // Start is called before the first frame update
    private void Start()
    {
        congratsPanel.SetActive(false);
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
        
        //Create key for num of obstacles to save for when next level progresses.
        if (PlayerPrefs.HasKey("NumObstacles"))
            numObstacles = PlayerPrefs.GetInt("NumObstacles");
        else
            PlayerPrefs.SetInt("NumObstacles", numObstacles);
        
        if (PlayerPrefs.HasKey("IsPlaying"))
            isPlaying = PlayerPrefs.GetString("IsPlaying");
        else
            PlayerPrefs.SetInt("NumObstacles", numObstacles);

        if (PlayerPrefs.HasKey("PlayerHealth"))
            health = PlayerPrefs.GetInt("PlayerHealth");
        else
            PlayerPrefs.SetInt("PlayerHealth", health);

        if (PlayerPrefs.HasKey("CurrentLevel"))
            currLevel = PlayerPrefs.GetInt("CurrentLevel");
        else
            PlayerPrefs.SetInt("CurrentLevel", currLevel);

        if (PlayerPrefs.HasKey("PlayerSpeed"))
            speed = PlayerPrefs.GetFloat("PlayerSpeed");
        else
            PlayerPrefs.SetFloat("PlayerSpeed", speed);

        if (PlayerPrefs.HasKey("PlayerJumpIntensity"))
            jumpIntensity = PlayerPrefs.GetFloat("PlayerJumpIntensity");
        else
            PlayerPrefs.SetFloat("PlayerJumpintensity", jumpIntensity);

        healthStart = health;
        speedStart = speed;

        if (isPlaying.Equals("True"))
        {
            mainMenuPanel.SetActive(false);
            StartCoroutine("CountDown");
        }
        else
            Time.timeScale = 0;
    }
    
    IEnumerator CountDown()
    {
        while(timer > 0)
        {
            yield return new WaitForSeconds(1);
            if(!isPaused)
                timer--;
            TimerText.text = timer.ToString();
        }

        
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
        congratsPanel.SetActive(true);
        
        yield return new WaitForSeconds(2);
        
        while (isPaused)
            yield return null;
        ChangeLevel();
    }

    private void ChangeLevel()
    {
        
        congratsPanel.SetActive(false);
        timer = 10;
        PlayerPrefs.SetInt("CurrentLevel", currLevel + 1);
        PlayerPrefs.SetInt("NumObstacles", numObstacles +1);
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.SetFloat("PlayerSpeed", speedStart + 2);
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        PlayerPrefs.SetString("IsPlaying", "True");
        Time.timeScale = 1;
        StartCoroutine("CountDown");
    }

    public void Restart()
    {
        timer = 10;
        Time.timeScale = 1;
        PlayerPrefs.SetInt("NumObstacles", numObstacles);
        PlayerPrefs.SetInt("PlayerHealth", healthStart);
        PlayerPrefs.SetFloat("PlayerSpeed", speedStart);
        SceneManager.LoadScene(0);
    }
    
    public void die()
    {
        timer = 10;
        PlayerPrefs.SetInt("NumObstacles", numObstacles);
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.SetFloat("PlayerSpeed", speedStart);
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = true;

    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;

    }

    // Update is called once per frame
    private void Update()
    {
        LevelText.text = "Level " + currLevel.ToString();
        HealthBarText.text = "Health: " + health.ToString()+"/100";
        healthBar.transform.localScale = new Vector3(health / 100f, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if (health <= 0)
            GameOver();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!!!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //Will run when in application mode not in unity editor.
        Application.Quit();
#endif
    }

    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("NumObstacles");
        PlayerPrefs.DeleteKey("CurrentLevel");
        PlayerPrefs.DeleteKey("PlayerSpeed");
        PlayerPrefs.DeleteKey("PlayerJumpIntensity");
        PlayerPrefs.DeleteKey("IsPlaying");
    }
}
