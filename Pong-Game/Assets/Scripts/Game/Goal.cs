using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameManager gameManager;

    public bool isPlayer1Goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            if(!isPlayer1Goal)
                gameManager.player1Scored();
            else
                gameManager.player2Scored();
        }
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
}
