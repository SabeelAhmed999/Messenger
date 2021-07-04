using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public float lerpTimer;
	public Vector3 UpRotation;
	public AudioSource audioSource;
    public Slider healthSlider;
	public GameObject particleObject;
	public int playerHealt;
	public Rigidbody rbPlayer;

	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;

	public GameObject removePlatform;
	public GameManager gameManager;

	public bool sheild;
	private bool moveLeft, moveRight,moveUP = false;

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
		if(Input.GetKey("w")||Input.GetAxis("Vertical")>0)
		{
			rbPlayer.AddForce(0,sidewaysForce*Time.deltaTime,0,ForceMode.VelocityChange);
		}
		if(Input.GetKey("s")||Input.GetAxis("Vertical")<0)
		{
			moveUP=true;
			removePlatform.gameObject.SetActive(false);
			rbPlayer.AddForce(0,-sidewaysForce*Time.deltaTime,0,ForceMode.VelocityChange);
		}
		if(Input.GetAxis("Vertical")==0&&moveUP)
		{
			rbPlayer.AddForce(0,10,0,ForceMode.VelocityChange);
			removePlatform.SetActive(true);
			removePlatform.GetComponent<Collider>().isTrigger=true;
			moveUP=false;
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
		if(!sheild)
		{
			if(healthSlider.value>0)
			{
				audioSource.Play();
				healthSlider.value -= 1;
			}
			else
			gameManager.LevelOver("You'r Dead");
		}
		else
			return;
    }
	private void OnTriggerExit(Collider other)
	{

		removePlatform.GetComponent<Collider>().isTrigger=false;
	}
}