using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 velocity;
    private AudioSource audioSource;

    public PlayerMovement playerMovement1;
    public PlayerMovement playerMovement2;
    public float xForce;
    public float yForce;

    public TextMeshProUGUI scoreLeft;
    public TextMeshProUGUI scoreRight;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI restartText;

    public AudioClip goalSound;
    public AudioClip paddleSound;
    public AudioClip wallSound;
    public AudioClip startSound;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        velocity = rb.velocity;

        velocity.x = Mathf.Clamp(velocity.x, -8f, 8f);
        velocity.y = Mathf.Clamp(velocity.y, -6f, 6f);

        rb.velocity = velocity;
    }

    void Start()
    {
        Invoke("StartBall", 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("GoalRight"))
        {
            audioSource.PlayOneShot(goalSound);
            GoalRight();
        }
        else if(other.CompareTag("GoalLeft"))
        {
            audioSource.PlayOneShot(goalSound);
            GoalLeft();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            audioSource.PlayOneShot(paddleSound);
        }
        else if(other.collider.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(wallSound);
        }
    }

    void Resetball()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Invoke("StartBall", 1);
    }

    void StartBall()
    {
        if(Random.Range(0, 2) < 1)
        {
            rb.AddForce(new Vector2(xForce, -yForce));
        }
        else
        {
            rb.AddForce(new Vector2(-xForce, -yForce));
        }

        audioSource.PlayOneShot(startSound);
    }

    void GoalRight()
    {
        scoreRight.text = (int.Parse(scoreRight.text) + 1).ToString();

        if(scoreRight.text == "7")
        {
            WinSystem("Player 2");
        }
        else
        {
            Resetball();
        }
    }
    void GoalLeft()
    {
        scoreLeft.text = (int.Parse(scoreLeft.text) + 1).ToString();

        if(scoreLeft.text == "7")
        {
            WinSystem("Player 1");
        }
        else
        {
            Resetball();
        }
    }
    
    void WinSystem(string player)
    {
        rb.velocity = Vector2.zero;

        playerMovement1.rb.velocity = Vector2.zero;
        playerMovement2.rb.velocity = Vector2.zero;
        playerMovement1.enabled = false;
        playerMovement2.enabled = false;

        winText.text = player + " wins!";
        winText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);

        StartCoroutine(RestartGame());
    }
    
    IEnumerator RestartGame()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
