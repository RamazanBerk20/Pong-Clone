using System.Collections;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip quitSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void QuitGameButton()
    {
        StartCoroutine(QuitGameCoroutine());
    }

    IEnumerator QuitGameCoroutine()
    {
        audioSource.PlayOneShot(quitSound);
        yield return new WaitForSeconds(quitSound.length);

        Application.Quit();
    }
}
