using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    private float fixedDeltaTime;
    private float Camspeed;
    /*[SerializeField] GameObject GameOver;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject RestartEnd;
    [SerializeField] GameObject MenuEnd;*/
    
    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
        /*GameOver.SetActive(false);
        scoreText.SetActive(false);
        panel.SetActive(false);
        RestartEnd.SetActive(false);
        MenuEnd.SetActive(false);*/

    }
    void start()
    {
        Camspeed = CameraController.CameraSpeed;
        this.fixedDeltaTime = Time.fixedDeltaTime;
        /*GameOver.SetActive(false);
        scoreText.SetActive(false);
        panel.SetActive(false);
        RestartEnd.SetActive(false);
        MenuEnd.SetActive(false);*/

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        /*if( PlayerLife.dead == true)
        {
            GameOver.SetActive(true);
            scoreText.SetActive(true);
            panel.SetActive(true);
            RestartEnd.SetActive(true);
            MenuEnd.SetActive(true);
            Debug.Log(PlayerLife.dead);
        }*/
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        CameraController.CameraSpeed = Camspeed;
        BackgroundScroller.dy = Camspeed;
        GamePaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log(Time.timeScale);
        Camspeed = CameraController.CameraSpeed;
        CameraController.CameraSpeed = 0.0f;
        BackgroundScroller.dy = 0.0f;
        GamePaused = true;

    }
    public void LoadStart()
    {
        Time.timeScale = 1f;
        CameraController.CameraSpeed = Camspeed;
        BackgroundScroller.dy = Camspeed;
        GamePaused = false;
        PlayerLife.dead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Restart()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        /*GameOver.SetActive(false);
        scoreText.SetActive(false);
        panel.SetActive(false);
        RestartEnd.SetActive(false);
        MenuEnd.SetActive(false);*/

        Time.timeScale = 1f;
        CameraController.CameraSpeed = Camspeed;
        BackgroundScroller.dy = Camspeed;
        GamePaused = false;
        PlayerLife.dead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
