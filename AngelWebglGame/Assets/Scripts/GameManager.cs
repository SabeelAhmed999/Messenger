﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject loading;
    public GameObject[] LevelObject;
    public GameObject gameOverStates;
    public CameraSmooth cameraSmooth;
    public static int Levelno=0;
    public static bool gameOver;
    public PlayerMovement angel;
    public  int triggerNo = 0;
    public  GameObject[] CubeTriggers;
    //Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            //cameraSmooth = GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraSmooth>();
            //CubeTriggers = GameObject.FindGameObjectsWithTag("Triggers");
            LevelObject[Levelno].SetActive(true);
            //angel = GameObject.FindGameObjectWithTag("Player").GetComponent<AngelController>();
        }

    }


    public void LevelComplete()
    {
        gameOver = true;
        loading.SetActive(true);
        gameOverStates.SetActive(false);
        gameOverStates.transform.GetChild(1).gameObject.SetActive(false);
        LevelObject[Levelno].SetActive(false);
        if(Levelno<=20)
        {
            Levelno += 1;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelObject[Levelno].SetActive(true);
    }
     
    public void LevelFailed()
    {
        gameOver = true;
        Time.timeScale = 0;
        cameraSmooth.enabled=false;
        gameOverStates.SetActive(true);
        gameOverStates.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        //gameOverStates.SetActive(false);
        //gameOverStates.transform.GetChild(2).gameObject.SetActive(false);
        gameOver = false;
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
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LevelOver()
    {
        gameOver = true;
        cameraSmooth.enabled = false;
        gameOverStates.SetActive(true);
        gameOverStates.transform.GetChild(1).gameObject.SetActive(true);
    }

    void RestartHold()
    {
        loading.SetActive(false);
    }
}
