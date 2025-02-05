using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    private IInputHandler inputHandler;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        inputHandler = new PlayerInputHandler(); // Dependency Injection
        Initialize(rigidbody, speed);
    }

    private void Update()
    {
        Vector2 movementDirection = inputHandler.GetMovementInput();
        Move(movementDirection);

        if (isGrounded && inputHandler.ShouldJump())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
    }

    
}