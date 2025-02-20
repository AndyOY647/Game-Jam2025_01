
using UnityEngine;

public class playerMovement : MonoBehaviour
{   
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizonalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizonalInput * speed, body.velocity.y);

        //Flip the player when moving left-right
        if (horizonalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizonalInput < -0.01f)
            transform.localScale = Vector3.one;

        if (Input.GetKey(KeyCode.W) && grounded)
            Jump();

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed * 2);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
