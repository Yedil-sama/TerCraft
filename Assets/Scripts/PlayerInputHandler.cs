using UnityEngine;

public class PlayerInputHandler : IInputHandler
{
    public Vector2 GetMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector2 (horizontal, vertical);
    }
    public bool ShouldJump()
    {
        return Input.GetButtonDown("Jump");
    }
}
