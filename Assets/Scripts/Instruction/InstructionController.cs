using UnityEngine;
using UnityEngine.UI;

public class InstructionController : MonoBehaviour
{
    private SpriteRenderer sR;
    public Sprite s;

    [SerializeField]
    private Button instruction, gamePauseButton;
    [SerializeField]
    private AudioClip buttonHitClip;

    private AudioSource audioSource;

    void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void _InstructionButton()
    {

        sR.sprite = s;
        Time.timeScale = 1;
        instruction.gameObject.SetActive(false);
        gamePauseButton.gameObject.SetActive(true);
        
        audioSource.clip = buttonHitClip;
        audioSource.Play();
    }

}
