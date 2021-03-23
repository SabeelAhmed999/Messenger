using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    
    public AngelController angel;
    public Timer modifyTime;
    public GameObject Sound;
    public string PowerName;
    public DirectionIndicator direction;
    public GameObject[] Books;
    public bool lastBook;
    public GameManager gameManager;
    static int BookCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //angel = GameObject.FindGameObjectWithTag("Player").GetComponent<AngelController>();
        //modifyTime = GameObject.FindGameObjectWithTag("TimeSlider").GetComponent<Timer>();
        //gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        Books = GameObject.FindGameObjectsWithTag("Book");
        direction = GameObject.FindGameObjectWithTag("DirectionalArrow").GetComponent<DirectionIndicator>();
        direction.target = Books[0].transform;

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0f, 2f, 0f,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Powerupssssssssss");
        if (other.tag=="Player"&&PowerName=="Spark")
        {
            angel.speed *= 2;
            angel.normalSpeed = true;
            Destroy(gameObject);
        }
        if (other.tag == "Player" && PowerName == "Shield")
        {
            angel.activeShield = true;
            Destroy(gameObject);
        }
        if (other.tag == "Player" && PowerName == "Timer")
        {
            modifyTime.gameTime += 2;
            angel.activeShield = true;
            Destroy(gameObject);
        }
        if (other.tag == "Player" && PowerName == "Book"&&!lastBook)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            BookCount += 1;
            direction.target = Books[BookCount].transform;
            Destroy(gameObject);
        }
        if (other.tag == "Player" && PowerName == "Book"&&lastBook)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameManager.LevelOver();
           // Destroy(gameObject);
        }

    }
}
