using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private AudioSource audioSource;
    [Header("Sounds")]
    public AudioClip buttonClickSound;
    public AudioClip quitGameSound;

    [Header("UI")]
    public Canvas mainMenu;
    public Canvas optionsMenu;
    public Canvas difficultyMenu;

    [Header("Options")]
    public TextMeshProUGUI vsyncText;

    public void StartLevel(int difficultyNum)
    {
        StartCoroutine(startLevelCoroutine(difficultyNum));
    }

    IEnumerator startLevelCoroutine(int difficultyNum)
    {
        PlaySound(buttonClickSound);
        yield return new WaitForSeconds(buttonClickSound.length);

        SceneManager.LoadSceneAsync(difficultyNum);
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameCoroutine());
    }

    IEnumerator QuitGameCoroutine()
    {
        PlaySound(quitGameSound);
        yield return new WaitForSeconds(quitGameSound.length);

        Application.Quit();
    }

    public void OpenDifficultyMenu()
    {
        PlaySound(buttonClickSound);
        mainMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        difficultyMenu.gameObject.SetActive(true);
    }

    public void OpenOptionsMenu()
    {
        PlaySound(buttonClickSound);
        mainMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(true);
    }

    public void VsyncToggle()
    {
        if(QualitySettings.vSyncCount == 0)
        {
            QualitySettings.vSyncCount = 1;

            vsyncText.text = "Vsync: On";
        }
        else
        {
            QualitySettings.vSyncCount = 0;

            vsyncText.text = "Vsync: Off";
        }

        PlaySound(buttonClickSound);
    }

    public void ReturnToMainMenu()
    {
        PlaySound(buttonClickSound);
        optionsMenu.gameObject.SetActive(false);
        difficultyMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    private void PlaySound(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (QualitySettings.vSyncCount == 0)
        {
            vsyncText.text = "Vsync: Off";
        }
        else
        {
            vsyncText.text = "Vsync: On";
        }
    }
}
