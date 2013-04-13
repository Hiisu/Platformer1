using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	CharacterController controller;
	float horizontalMovementSpeed = 5.0f;
	
	public float speed = 3.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 10.0F;
    private Vector3 moveDirection = Vector3.zero;
	private bool can_climb = false;

	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (controller.isGrounded) 
		{
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = base.transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
		}
		
		
			
		if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
            moveDirection.y = jumpSpeed;
		}
		else if (can_climb && Input.GetKey(KeyCode.C))
		{
			moveDirection.x = Input.GetAxis("Horizontal") * speed;
			moveDirection.y = jumpSpeed;	
			
		}
		else
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}
		
        controller.Move(moveDirection * Time.deltaTime);
		
	}
	
	void OnTriggerEnter()
	{
		can_climb = true;
	}
	
	
	
	void OnTriggerExit()
	{
		can_climb = false;
		
	}
	
	
}
