using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const string BEST_SCORE = "Best Score";
    void Awake()
    {
        _MakeSingleInstance();

    }

    void IsGameStartForTheFisrtTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartForTheFisrtTime"))
        {
            PlayerPrefs.SetInt(BEST_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartForTheFisrtTime", 0);
        }
    }

    void _MakeSingleInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void _SetBestScore(int score)
    {
        PlayerPrefs.SetInt(BEST_SCORE, score);
    }

    public int _GetBestScore()
    {
        return (PlayerPrefs.GetInt(BEST_SCORE));
    }

}
