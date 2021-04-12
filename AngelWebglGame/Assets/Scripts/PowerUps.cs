using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    
    public PlayerMovement PlayerMovement;
    public Timer modifyTime;
    public string PowerName;
    public GameObject[] Books;
    public bool lastBook;
    public GameManager gameManager;
    static int BookCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0f, 2f, 0f,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"&&PowerName=="Spark")
        {
            PlayerMovement.forwardForce *= 2;
            PlayerMovement.particleObject[0].SetActive(true);
            PlayerMovement.audioSource.clip=PlayerMovement.clips[1];
            PlayerMovement.audioSource.Play();
            StartCoroutine(BringNormal("Speed"));

        }
        if (other.tag == "Player" && PowerName == "Shield")
        {

            Destroy(gameObject);
        }
        if (other.tag == "Player" && PowerName == "Timer")
        {
            modifyTime.gameTime += 3;
            Destroy(gameObject);
        }
        if (other.tag == "Player" && PowerName == "Book"&&!lastBook)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            BookCount += 1;
            Destroy(gameObject);
        }
        if (other.tag == "Player" && PowerName == "Book"&&lastBook)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameManager.LevelOver();
           // Destroy(gameObject);
        }

    }
    IEnumerator BringNormal(string what)
    {
        Debug.Log("I'm in the coroutine");
        if(what=="Speed")
        {
            yield return new WaitForSeconds(3f);
            PlayerMovement.forwardForce/=2;
            PlayerMovement.particleObject[0].SetActive(false);
            Debug.Log("I'm done with the if statement");
            Destroy(gameObject);
        }

        yield return null;
    }
}
