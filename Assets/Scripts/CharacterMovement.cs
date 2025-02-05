using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IMovable
{
    [SerializeField] protected float speed;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected List<string> jumpableTags;
    protected bool isGrounded;
    protected Rigidbody2D rigidbody;

    public CharacterMovement() { }
    public void Initialize(Rigidbody2D rigidbody, float speed)
    {
        this.rigidbody = rigidbody;
        this.speed = speed;
    }

    public virtual void Move(Vector2 direction)
    {
        rigidbody.velocity = new Vector2(direction.x * speed, rigidbody.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        for(int i = 0; i < jumpableTags.Count; i++)
        {
            if (collision.gameObject.CompareTag(jumpableTags[i]))
            {
                isGrounded = true;
            }
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        for (int i = 0; i < jumpableTags.Count; i++)
        {
            if (collision.gameObject.CompareTag(jumpableTags[i]))
            {
                isGrounded = false;
            }
        }
    }
}