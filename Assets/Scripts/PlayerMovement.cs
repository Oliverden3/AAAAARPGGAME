using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    private gameObject gameManager;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");
        statManager toSpeed = gameManager.GetComponent<statManager>();
        speed = toSpeed.getSpeed;
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        // apply movement to rigidbody
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);

    }
}
