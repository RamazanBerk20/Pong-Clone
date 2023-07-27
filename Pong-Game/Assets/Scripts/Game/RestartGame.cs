using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public int mainMenuSeconds;

    private GameManager gameManager;
    private TextMeshProUGUI secondsText;

    IEnumerator ReturnToMainMenuCoroutine()
    {
        for (int i = mainMenuSeconds; i > 0; i--)
        {
            secondsText.text = i.ToString() + " Seconds to Main Menu";
            yield return new WaitForSeconds(1);
        }

        gameManager.ReturnToMainMenu();
    }

    IEnumerator RestartGameCoroutine()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        secondsText = gameManager.secondsText;
    }

    private void Start()
    {
        StartCoroutine(ReturnToMainMenuCoroutine());
        StartCoroutine(RestartGameCoroutine());
    }
}
