using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadAngelController : MonoBehaviour
{
    public Animator animator;
    public AngelController angel;
    public ParticleSystem hitParticles;
    bool hit = true;
    bool flick = false;
    // Start is called before the first frame update

    private void Awake()
    {
        Debug.Log("BadAngelAngelReferanceget");
       // angel = GameObject.FindGameObjectWithTag("Player").GetComponent<AngelController>();
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
            transform.LookAt(angel.transform);
            animator.SetBool("MoveUp", true);
            Invoke("StopHit", 3f);
            if(hit)
            {
                gameObject.GetComponent<SphereCollider>().enabled = false;
                angel.GetComponent<AngelController>().enabled = false;
                hitParticles.Play();
                angel.MinusHealth();
                flick = true;
                hit = false;
            }

        }
    }

    void StopHit()
    {
        angel.GetComponent<AngelController>().enabled = true;
        animator.SetBool("MoveUp", false);
        hit = true;
        flick = false;
    }

    IEnumerator AngelFlicker()
    {
        float timedelay;
        angel.transform.GetChild(0).gameObject.SetActive(false);
        timedelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timedelay);
        angel.transform.GetChild(0).gameObject.SetActive(true);
        timedelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timedelay);
    }
}
