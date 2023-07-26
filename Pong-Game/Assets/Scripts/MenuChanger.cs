using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas settingsMenu;
    public AudioClip menuSound;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void changeToSettings()
    {
        audioSource.PlayOneShot(menuSound);
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(true);
    }

    public void changeToMainMenu()
    {
        audioSource.PlayOneShot(menuSound);
        mainMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changeToMainMenu();
        }
    }
}
