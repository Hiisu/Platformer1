using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	CharacterController controller;
	float horizontalMovementSpeed = 5.0f;
	
	public float speed = 8.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
	
	public float Acceleration = 10;
	public float MaxVelocity = 700;
	public float SlowToFastVelocity = 600;
	public float BrakingVelociy = 18;
	
	public enum PlayerState
		{
			Starting,
			Standing,
			MovingRight,
			FastMovingRight,
			KnockedBack,
			Jumping,
			Killed	
		};

   private PlayerState state;
	
	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
	
			
		state = PlayerState.Standing;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (controller.isGrounded) 
		{
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			
            moveDirection = base.transform.TransformDirection(moveDirection);
            moveDirection *= speed;
			
            if (Input.GetKeyDown(KeyCode.Space))
			{
                moveDirection.y = jumpSpeed;
			}
		}
		
				
		moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
		
	}
	
}
