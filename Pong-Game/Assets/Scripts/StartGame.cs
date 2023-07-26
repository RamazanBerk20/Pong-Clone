using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip startSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGameButton()
    {
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        audioSource.PlayOneShot(startSound);
        yield return new WaitForSeconds(startSound.length);

        SceneManager.LoadScene(1);
    }
}
