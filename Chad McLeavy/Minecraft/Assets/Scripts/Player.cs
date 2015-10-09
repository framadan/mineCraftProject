using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float movementSpeed = 0.0f;
	public float mouseSensitivity = 0.0f;
	public float jumpVelocity = 0.0f;
	public float verticalRotation = 0.0f;
	public float upDownRotationLimit = 0.0f;
	public float verticalVelocity = 0.0f;
	public float distance = 8.0f;
	public float mobSoundRadius = 5.0f;

	//PlayerIdol
	//public float timeSpentIdol1 = 0.0f;
	//public float timeSpentIdol2 = 0.0f;

	public int attack = 2;
	public int knockBack = 500;

	public bool cursorLocked;

	public GameObject block;
	public GameObject normalArm;
	public GameObject armPunch;
	public GameObject hotbarReference;
	public GameObject armHotbar;
	public GameObject armPunchHotbar;
	public GameObject blockType;
	public GameObject newBlockType;
	public GameObject gameManager;
	
	public Collider[] mobs;

	public AudioSource punch;
	public AudioSource placeBlock;
	public AudioSource zombie;
	public AudioSource skeleton;
	public AudioSource creeper;
	public AudioSource cow;
	public AudioSource sheep;
	public AudioSource pig;

	public Sprite newSprite;
	public Sprite armHotbarSprite;
	public Sprite armPunchSprite;

	// Use this for initialization
	void Start () 
	{
		normalArm.SetActive (true);
		armPunch.SetActive (false);
		cursorLocked = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerMovement ();
		PlaceBlocks ();
		BreakBlocks ();
		Attack ();
		ChangSprite ();
		AddToGameManager ();
		LockCursor ();

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
		
		if (!cc.isGrounded) 
		{
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}
		
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
			normalArm.SetActive(false);
			armPunch.SetActive(true);
			Ray rayOrigin = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
				
			if (Physics.Raycast (rayOrigin, out hitInfo, distance))
			{
				if (blockType != null)
				{
					if (hitInfo.collider.gameObject.layer == 10)
					{
						Instantiate (blockType, hitInfo.collider.transform.position + hitInfo.normal , Quaternion.identity);
						placeBlock.Play ();
						if (blockType.tag == "Stone Block")
						{
							gameManager.GetComponent<GameManager>().stone -= 1;
						}
						if (blockType.tag == "Dirt Block")
						{
							gameManager.GetComponent<GameManager>().dirt -= 1;
						}
						if (blockType.tag == "Wood Block")
						{
							gameManager.GetComponent<GameManager>().wood -= 1;
						}
					}
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse1)) 
		{
			normalArm.SetActive(true);
			armPunch.SetActive(false);
		}
	}

	void BreakBlocks ()
	{
		if (Input.GetKey (KeyCode.Mouse0)) 
		{
			Ray rayOrigin = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;

			if (Physics.Raycast (rayOrigin, out hitInfo, distance))
			{
				if (hitInfo.collider.gameObject.layer == 10)
				{
					hitInfo.collider.gameObject.GetComponent<Block>().breakTimer -= Time.deltaTime;
				}
			}

		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) 
		{
			Ray rayOrigin = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			
			if (Physics.Raycast (rayOrigin, out hitInfo, distance))
			{
				if (hitInfo.collider.gameObject.layer == 10)
				{
					hitInfo.collider.gameObject.GetComponent<Block>().breakTimer = 
					hitInfo.collider.gameObject.GetComponent<Block>().breakTimerReset;
				}
			}
		}
	}

	void Attack ()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			normalArm.SetActive(false);
			armPunch.SetActive(true);
			Ray rayOrigin = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			
			if (Physics.Raycast (rayOrigin, out hitInfo, 4.0f)) 
			{

				if (hitInfo.collider.gameObject.layer == 11)
				{
					hitInfo.collider.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * knockBack);
					hitInfo.collider.gameObject.GetComponent<Rigidbody>().AddForce (transform.up * knockBack);
					hitInfo.collider.gameObject.GetComponent<DeathCode>().health -= attack;

					//Adio on hit
					if (hitInfo.collider.gameObject.tag == "Zombie")
					{
						punch.Play ();
						zombie.Play ();
					}
					if (hitInfo.collider.gameObject.tag == "Skeleton")
					{
						punch.Play ();
						skeleton.Play ();
					}
					if (hitInfo.collider.gameObject.tag == "Creeper")
					{
						punch.Play ();
						creeper.Play ();
					}
					if (hitInfo.collider.gameObject.tag == "Cow")
					{
						punch.Play ();
						cow.Play ();
					}
					if (hitInfo.collider.gameObject.tag == "Sheep")
					{
						punch.Play ();
						sheep.Play ();
					}
					if (hitInfo.collider.gameObject.tag == "Pig")
					{
						punch.Play ();
						pig.Play ();
					}
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) 
		{
			normalArm.SetActive(true);
			armPunch.SetActive(false);
		}
	}

	void ChangSprite ()
	{
		armHotbar.GetComponent<SpriteRenderer>().sprite = armHotbarSprite;
		armPunchHotbar.GetComponent<SpriteRenderer>().sprite = armPunchSprite;
	}

	void AddToGameManager ()
	{
		if (newSprite != null) 
		{
			if (newSprite.name == "Stone") 
			{
				newSprite = null;
				gameManager.GetComponent<GameManager> ().stone += 1;
			}
			else if (newSprite.name == "Dirt") 
			{
				newSprite = null;
				gameManager.GetComponent<GameManager> ().dirt += 1;
			}
			else if (newSprite.name == "Wood") 
			{
				newSprite = null;
				gameManager.GetComponent<GameManager> ().wood += 1;
			}
		}
	}

	void LockCursor () 
	{
		if (cursorLocked == true && Input.GetKeyDown (KeyCode.Escape)) 
		{
			cursorLocked = false;
			print ("cursor unlocked");
		} 
		else if (cursorLocked == false && Input.GetKeyDown (KeyCode.Escape)) 
		{
			cursorLocked = true;
			print ("cursor locked");
		}
		if (cursorLocked == true) 
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		else if (cursorLocked == false) 
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.layer == 9) 
		{
			newBlockType = other.gameObject.GetComponent<MobDrop>().blockType;
			newSprite = other.gameObject.GetComponent<MobDrop>().spriteStorage;
			hotbarReference.GetComponent<Hotbar>().UpdateItems ();
			Destroy (other.gameObject,0.0f);
		}
	}

//For when the hotbar is ready
//	void HotbarSwitch ()
//	{
//		if (Input.GetKeyDown (KeyCode.1)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.2)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.3)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.4)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.5)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.6)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.7)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.8)) 
//		{
//			
//		}
//		if (Input.GetKeyDown (KeyCode.9)) 
//		{
//			
//		}
//	}
}
