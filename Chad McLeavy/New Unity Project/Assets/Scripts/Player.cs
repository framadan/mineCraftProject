using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float movementSpeed = 0.0f;
	public float mouseSensitivity = 0.0f;
	public float jumpVelocity = 0.0f;

	float verticalRotation = 0.0f;
	public float upDownRotationLimit = 0.0f;

	float verticalVelocity = 0.0f;

	//PlayerIdol
	//public float timeSpentIdol1 = 0.0f;
	//public float timeSpentIdol2 = 0.0f;

	public int health = 20;
	public int attack = 1;

	public float distance = 8.1f;

	public GameObject block = null;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		PlaceBlocks ();
		BreakBlocks ();
		PlayerMovement ();

		//Player Idol
		//Note: Code Works Just Messy

		//if (Mathf.Abs(Input.GetAxis("Vertical")) <= 0.1)
		//{
		//
		//	if(timeSpentIdol1 >= 0)
		//	{
		//		timeSpentIdol1 = timeSpentIdol1 - 1 * Time.deltaTime;
		//		if(timeSpentIdol1 <= 0)
		//		{
		//			GetComponent<AudioSource>().Play();
		//		}
		//	}
		//
		//	if(timeSpentIdol1 <=0)
		//	{
		//		timeSpentIdol2 = timeSpentIdol2 - 1 * Time.deltaTime;
		//		if(timeSpentIdol2 <= 0)
		//		{
		//			GetComponent<AudioSource>().Play ();
		//		}
		//	}
		//}
		
	}

	void PlayerMovement ()
	{
		CharacterController cc = GetComponent<CharacterController>();
		
		//Rotation
		
		float leftRightRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate (0, leftRightRotation, 0);
		
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRotationLimit, upDownRotationLimit);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
		
		
		//Movement
		
		float fowardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
		
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		
		if(cc.isGrounded && Input.GetButtonDown("Jump"))
		{
			verticalVelocity = jumpVelocity;
		}
		
		Vector3 speed = new Vector3(sideSpeed, verticalVelocity, fowardSpeed);
		
		speed = transform.rotation * speed;
		
		cc.Move(speed * Time.deltaTime);

	}

	void PlaceBlocks ()
	{
		if (Input.GetKeyDown (KeyCode.Mouse1)) 
		{
			Ray rayOrigin = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
				
			if (Physics.Raycast (rayOrigin, out hitInfo, 8.0f))
			{
				hitInfo.collider.gameObject.transform.Translate (Vector3.up * 0.9f);
				Instantiate (block, hitInfo.collider.transform.position, Quaternion.identity);
			}
		}
	}

	void BreakBlocks ()
	{
		if (Input.GetKey (KeyCode.Mouse0)) 
		{
			Ray rayOrigin = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			
			if (Physics.Raycast (rayOrigin, out hitInfo, 8.0f))
			{
				hitInfo.collider.gameObject.GetComponent<Block>().breakTimer -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) 
		{
			Ray rayOrigin = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			
			if (Physics.Raycast (rayOrigin, out hitInfo, 8.0f))
			{
				hitInfo.collider.gameObject.GetComponent<Block>().breakTimer = 
				hitInfo.collider.gameObject.GetComponent<Block>().breakTimerReset;
			}
		}
	}

//For when the hotbar is ready
//	void HotbarSwitch ()
//	{
//		if (Input.GetKeyDown (KeyCode.Keypad1)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.Keypad2)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.Keypad3)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.Keypad4)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.Keypad5)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.Keypad6)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.Keypad7)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.Keypad8)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.Keypad9)) 
//		{
//			
//		}
//	}
}
