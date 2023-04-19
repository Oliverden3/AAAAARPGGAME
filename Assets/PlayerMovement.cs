using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // movement speed in units per second

    private Rigidbody2D rb2d;
    private Vector2 movement;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // read input axes
    }

    void FixedUpdate()
    {
        // apply movement to rigidbody
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
