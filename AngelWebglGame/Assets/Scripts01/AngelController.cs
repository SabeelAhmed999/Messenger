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
    public Rigidbody rbPlayer;
    public float sidewaysForce=100f;
    public float forwardForce = 500f;
    float HAxis,VAxis;
    public bool normalSpeed,activeShield;
    public int angelHealth;
    /// <summary>
    public float speed = 20f;
    public float rotationSpeed,rotation = 10;


    void Update()
    {


        VAxis = Input.GetAxis("Vertical");
        HAxis = Input.GetAxis("Horizontal");




        if (normalSpeed)
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
        animator.SetFloat("VerticalMove", VAxis);
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
