using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class AngelController : MonoBehaviour
{
    public Animator animator;
    public GameObject Sound;
    public Slider healthSlider;
    public GameObject[] sparkParticles;
    public Transform rb;
    float HAxis,VAxis;
    public bool normalSpeed,activeShield;
    public int angelHealth;
    /// <summary>
    public float speed = 20f;
    public float rotationSpeed,rotation = 10;
    /// </summary>
    // Start is called before the first frame update

    private void Awake()
    {
        healthSlider = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
        healthSlider.maxValue = angelHealth;
        healthSlider.value = angelHealth;
    }

    void Start()
    {
        
        Time.timeScale = 0;

        if(GameManager.Levelno<6)
        {
            angelHealth = 5;
        }

        if (GameManager.Levelno < 10 && GameManager.Levelno > 5)
        {
            angelHealth = 4;
        }

        if (GameManager.Levelno < 16 && GameManager.Levelno > 10)
        {
            angelHealth = 3;
        }

        if (GameManager.Levelno < 21 && GameManager.Levelno > 15)
        {
            angelHealth = 2;
        }


    }

    // Update is called once per frame
    void Update()
    {
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        float translation = 1*speed;
        if(translation<0)
        {
            translation = translation * 0;
        }
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0f, 0f, translation);
        transform.Rotate(0f, rotation, 0f);

        VAxis = Input.GetAxis("Vertical");
        HAxis = Input.GetAxis("Horizontal");


        if(normalSpeed)
        {

            Sound.SetActive(true);
            sparkParticles[0].SetActive(true);
            Invoke("BringToNormal01", 3f);
        }
        if(activeShield==true)
        {
            sparkParticles[1].SetActive(true);
            Invoke("BringToNormal02", 3f);
        }
        animator.SetFloat("HorizontalMove", HAxis);
        animator.SetFloat("VerticalMove", 1);
    }

    private void FixedUpdate()
    {

    }

    void BringToNormal01()
    {
        speed = 20f;
        Sound.SetActive(false);
        normalSpeed = false;
        sparkParticles[0].SetActive(false);
    }

    void BringToNormal02()
    {
        speed = 20f;
        activeShield = false;
        sparkParticles[1].SetActive(false);
    }

    public void MinusHealth()
    {
        healthSlider.value -= 1;
    }

}
