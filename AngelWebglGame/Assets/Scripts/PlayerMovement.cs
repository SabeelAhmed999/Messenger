using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public AudioClip[] clips;
	public AudioSource audioSource;
    public Slider healthSlider;
	public GameObject[] particleObject;
	public int playerHealt;
	public Rigidbody rbPlayer;

	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;
	private bool moveLeft, moveRight = false;

	private void Awake()
	{
		rbPlayer = gameObject.GetComponent<Rigidbody>();
		healthSlider.maxValue=playerHealt;
		healthSlider.value=playerHealt;
	}
	void FixedUpdate()
	{
		// Add a forward force
		rbPlayer.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d") || moveRight|| Input.GetAxis("Horizontal")>0)
		{
			// Add a force to the right
			rbPlayer.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a") || moveLeft || Input.GetAxis("Horizontal") < 0)
		{
			// Add a force to the left
			rbPlayer.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

	}
	public void MoveDirection(string direction)
	{
		if (direction == "Right")
		{
			moveRight = true;
			moveLeft = false;
		}
		if (direction == "Left")
		{
			moveRight = false;
			moveLeft = true;
		}
		if (direction == "Stop")
		{
			moveRight = false;
			moveLeft = false;
		}
	}

	public void MinusHealth()
    {
        healthSlider.value -= 1;
    }
}