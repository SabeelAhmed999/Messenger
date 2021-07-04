using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{Running,Pause,Restart,Resume,Over,}
public class GameStateController : MonoBehaviour
{
    public static GameStateController Instance {get;set;}
    public GameState gameState=GameState.Running;
    private void Awake() {
        if(Instance==null)
        {
            Instance=this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    } 

    public void GameOver(string msg)
    {

    }

    public void CurrentState(GameState currentstate)
    {
        switch(currentstate)
        {
            case GameState.Pause:
                Time.timeScale=0;
                break; 
            case GameState.Resume:
                Time.timeScale=1;
                break;
            case GameState.Restart:
                Time.timeScale=1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }
}
