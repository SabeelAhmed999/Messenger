using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    
    public PlayerMovement PlayerMovement;
    public Timer modifyTime;
    public string PowerName;

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
        if (other.tag == "Player" && PowerName == "Shield")
        {
            PlayerMovement.particleObject.SetActive(true);
            PlayerMovement.sheild=true;
            gameManager.OnSheild();
            StartCoroutine(BringNormal("Shield"));
        }
        if (other.tag == "Player" && PowerName == "Timer")
        {
            modifyTime.gameTime += 3;
            gameManager.SoundToPlay();
            Destroy(gameObject,0.5f);
        }

        if (other.tag == "Player" && PowerName == "Book")
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameManager.AddBook();
            Destroy(gameObject,0.5f);
        }

    }
    IEnumerator BringNormal(string what)
    {
        if(what=="Shield")
        {
            yield return new WaitForSeconds(5f);
            PlayerMovement.particleObject.SetActive(false);
            PlayerMovement.sheild=false;
            Destroy(gameObject);
        }

        yield return null;
    }
}
