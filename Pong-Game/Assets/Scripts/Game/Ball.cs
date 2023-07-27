using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private GameManager gameManager;

    public float speed = 800f;

    private float difficulty;

    public void ResetBall()
    {
        StopAllCoroutines();

        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        Launch();
    }

    public void Launch()
    {
        StartCoroutine(LaunchCoroutine());
    }

    public IEnumerator LaunchCoroutine()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        yield return new WaitForSeconds(2);

        rb2d.velocity = new Vector2(x * speed * difficulty * Time.deltaTime, y * speed * difficulty * Time.deltaTime);
        gameManager.PlaySound(gameManager.launchSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameManager.PlaySound(gameManager.playerHitSound);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            gameManager.PlaySound(gameManager.wallHitSound);
        }
    }

    private void ClampVelocity()
    {
        Vector2 vel = rb2d.velocity;
        vel.x = Mathf.Clamp(vel.x, -5.34f * difficulty, 5.34f * difficulty);
        vel.y = Mathf.Clamp(vel.y, -5.34f * difficulty, 5.34f * difficulty);
        rb2d.velocity = vel;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        difficulty = gameManager.difficultyFactor;
    }

    private void Start()
    {
        Launch();
    }

    private void Update()
    {
        ClampVelocity();
    }
}
