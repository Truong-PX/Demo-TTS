using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private AudioClip backGroundClip, buttonHit;

    private AudioSource audioSource;

     void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backGroundClip;
        audioSource.Play();
    }

    public void _PlayButton()
    {
        SceneManager.LoadScene("GamePlay");
        audioSource.clip = buttonHit;
        audioSource.Play();
    }
}
