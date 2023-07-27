using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 800f;
    public bool isPlayer1;

    private Rigidbody2D rb2d;
    private GameManager gameManager;

    private float yAxis;
    private float difficulty;

    public void ResetPos()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(transform.position.x, 0);
    }

    private void ClampTransform()
    {
        Vector2 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -4.3f, 4.3f);
        transform.position = pos;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        difficulty = gameManager.difficultyFactor;
    }

    private void Update()
    {
        ClampTransform();

        if (isPlayer1)
        {
            yAxis = Input.GetAxisRaw("Vertical");
        }
        else
        {
            yAxis = Input.GetAxisRaw("Vertical2");
        }

        rb2d.velocity = new Vector2(rb2d.velocity.x, yAxis * speed * difficulty * Time.deltaTime);
    }
}
