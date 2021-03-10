using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, scoreText1, bestScoreText;
    [SerializeField]
    private Button restartButton, mainMenuButton, gamePauseButton, continueButton, audioButton, audio1button, mainMenu1Button;
    [SerializeField]
    private GameObject gameOverPanel, gamePausePanel;
    [SerializeField]
    private AudioClip buttonHitClip;

    private AudioSource audioSource;
    private int score;

    void Awake()
    {
        _MakeInstance();
        Time.timeScale = 0;
        gamePauseButton.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void _MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void _SetScore()
    {
        score++;
        scoreText.text = "" + score;
    }

    public void _ShowGameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(true);
        gamePauseButton.gameObject.SetActive(false);
        Time.timeScale = 0;
        scoreText1.text = "Score " + score;

        if (score > GameManager.instance._GetBestScore())
        {
            GameManager.instance._SetBestScore(score);
        }
        bestScoreText.text = "Best Score " + GameManager.instance._GetBestScore();
    }  

    public void _RestartButton()
    {
        SceneManager.LoadScene("GamePlay");
        audioSource.clip = buttonHitClip;
        audioSource.Play();
    }

    public void _MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        audioSource.clip = buttonHitClip;
        audioSource.Play();
    }

    public void _GamePauseButton()
    {
        Time.timeScale = 0;
        gamePauseButton.gameObject.SetActive(false);
        gamePausePanel.gameObject.SetActive(true);
        audioSource.clip = buttonHitClip;
        audioSource.Play();
    }

    public void _ContinueButton()
    {
        Time.timeScale = 1;
        gamePausePanel.gameObject.SetActive(false);
        gamePauseButton.gameObject.SetActive(true);
        audioSource.clip = buttonHitClip;
        audioSource.Play();
    }
}
