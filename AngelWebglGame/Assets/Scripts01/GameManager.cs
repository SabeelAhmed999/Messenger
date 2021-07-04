using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject loading;
    public GameObject[] LevelObject;
    public GameObject gameOverStates;
    public TMP_Text gameOverMessage;
    public FollowPlayer followCamer;
    public static int Levelno=0;
    public  bool gameOver;
    public PlayerMovement angel;
    public  int triggerNo = 0;
    public Text scoreTxt;
    public  GameObject[] CubeTriggers;

    public AudioSource collectSound,shieldSound;

    public int BooksCollected;
    //Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale=0;
            //cameraSmooth = GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraSmooth>();
            //CubeTriggers = GameObject.FindGameObjectsWithTag("Triggers");
            //LevelObject[Levelno].SetActive(true);
            //angel = GameObject.FindGameObjectWithTag("Player").GetComponent<AngelController>();
        }

    }
    private void Start() {
        gameOver=false;
    }

    public void LevelComplete()
    {
        if(!gameOver)
        {
            gameOver = true;
            loading.SetActive(true);
            gameOverStates.SetActive(false);
            gameOverStates.transform.GetChild(1).gameObject.SetActive(false);
//            LevelObject[Levelno].SetActive(false);
            if(Levelno<=20)
            {
                Levelno += 1;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           // LevelObject[Levelno].SetActive(true);
        }
    }
     
    public void LevelFailed()
    {
        Debug.Log("LevelFailedISCalling");
        gameOver = true;
        Time.timeScale = 0;
        followCamer.enabled=false;
        gameOverStates.SetActive(true);
        gameOverStates.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        gameOverStates.SetActive(false);
        gameOverStates.transform.GetChild(2).gameObject.SetActive(false);
        loading.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeScreen()
    {
        gameOver = false;
        loading.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void pause()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void NextScene(int sceneIndex)
    {
        gameOver = false;
        loading.SetActive(true);
        Levelno = sceneIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LevelOver(string message)
    {
        gameOver = true;
        followCamer.enabled = false;
        gameOverStates.SetActive(true);
        gameOverStates.transform.GetChild(2).gameObject.SetActive(true);
        gameOverMessage.text=message;
        Time.timeScale=0;
    }

    void RestartHold()
    {
        loading.SetActive(false);
    }

    public void AddBook()
    {
        collectSound.Play();
        BooksCollected++;
        scoreTxt.text=BooksCollected.ToString();
    }
    public void SoundToPlay( )
    {
        collectSound.Play();
    }

    public void OnSheild()
    {
        shieldSound.Play();
    }
}
