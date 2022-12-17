using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI;
    private float fixedDeltaTime;
    private float Camspeed;

    // Start is called before the first frame update
    void Start()
    {
        Camspeed = CameraController.CameraSpeed;
        this.fixedDeltaTime = Time.fixedDeltaTime;
        GameOverUI.SetActive(false);
    }
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerLife.dead + " " + GameOverUI.active);
        if (PlayerLife.dead == true) {
            GameOverUI.SetActive(true);
        }
        else {
            GameOverUI.SetActive(false);
        }

    }
    public void Restart()
    {
        //GameOverUI.SetActive(false);
        
        this.fixedDeltaTime = Time.fixedDeltaTime;
        Time.timeScale = 1f;
        CameraController.CameraSpeed = Camspeed;
        BackgroundScroller.dy = Camspeed;
        PlayerLife.dead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        //GameOverUI.SetActive(false);
        Time.timeScale = 1f;
        CameraController.CameraSpeed = Camspeed;
        BackgroundScroller.dy = Camspeed;
        PlayerLife.dead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
