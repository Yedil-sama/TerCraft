using UnityEngine;
public interface IInputHandler
{
    Vector2 GetMovementInput();
    bool ShouldJump();
}