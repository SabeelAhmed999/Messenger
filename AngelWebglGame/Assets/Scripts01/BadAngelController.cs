using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadAngelController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public ParticleSystem hitParticles;
    bool hit = true;
    bool flick = false;
    //Start is called before the first frame update

    private void Awake()
    {
        transform.Rotate(0,180,0);
       //angel = GameObject.FindGameObjectWithTag("Player").GetComponent<AngelController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(flick)
        {
            StartCoroutine(AngelFlicker());
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            //transform.LookAt(angel.transform);
            Invoke("StopHit", 1f);
            if(hit&&playerMovement.sheild==false)
            {
                gameObject.GetComponent<Collider>().enabled = false; 
                playerMovement.GetComponent<Rigidbody>().isKinematic = true;
                hitParticles.Play();
                playerMovement.MinusHealth();
                flick = true;
                hit = false;
                //AngelController.NormalState=true;
            }
            else
                return;

        }
    }

    void StopHit()
    {
        playerMovement.GetComponent<Rigidbody>().isKinematic = false;
        hit = true;
        flick = false;
    }

    IEnumerator AngelFlicker()
    {
        float timedelay;
        playerMovement.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled=false;
        timedelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timedelay);
        playerMovement.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled=true;
        timedelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timedelay);
    }
}
