using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 100f;
    public int playerNumber;
    
    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 position = transform.position;
        position.y = Mathf.Clamp(position.y, -4.5f, 4.5f);
        transform.position = position;

        if (playerNumber == 1)
        {
            if(Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed * Time.deltaTime);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
        else if (playerNumber == 2)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed * Time.deltaTime);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }
}
