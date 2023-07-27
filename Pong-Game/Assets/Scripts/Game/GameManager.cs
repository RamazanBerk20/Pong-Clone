using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Players")]
    public GameObject player1;
    public GameObject player2;

    [Header("Goals")]
    public GameObject player1Goal;
    public GameObject player2Goal;

    [Header("Walls")]
    public GameObject topWall;
    public GameObject bottomWall;

    [Header("Sounds")]
    public AudioClip wallHitSound;
    public AudioClip playerHitSound;
    public AudioClip goalSound;
    public AudioClip launchSound;

    private AudioSource audioSource;

    [Header("UI")]
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI secondsText;

    [Header("Scores")]
    private int player1Score = 0;
    private int player2Score = 0;

    [Header("Game Settings")]
    public float difficultyFactor = 1;

    public void PlaySound(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

    public void player1Scored()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();

        player1.GetComponent<Player>().ResetPos();
        player2.GetComponent<Player>().ResetPos();
        ball.GetComponent<Ball>().ResetBall();

        CheckWin();
        PlaySound(goalSound);
    }

    public void player2Scored()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();

        player1.GetComponent<Player>().ResetPos();
        player2.GetComponent<Player>().ResetPos();
        ball.GetComponent<Ball>().ResetBall();

        CheckWin();
        PlaySound(goalSound);
    }

    private void playerWon(int playerNumber)
    {
        ball.GetComponent<Ball>().StopAllCoroutines();
        player1.GetComponent<Player>().enabled = false;
        player2.GetComponent<Player>().enabled = false;

        winText.text = "Player " + playerNumber + " won!";
        winText.gameObject.SetActive(true);
    }
    
    private void CheckWin()
    {
        if(player1Score == 7)
        {
            playerWon(1);
        }
        else if(player2Score == 7)
        {
            playerWon(2);
        }
    }

    public void ReturnToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync(0);
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

}
