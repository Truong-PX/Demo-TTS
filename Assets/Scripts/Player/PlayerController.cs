using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float bounceForce = 5;

    private Animator anim;
    private Rigidbody2D rb;
    private bool isAlive;
    private bool isPipe;
    public Transform pipeCheck;
    public LayerMask whatIsPipe;
    private int extraJumpValue;

    [SerializeField]
    private int extraJump;

    [SerializeField]
    private Button jumpingButton;

    [SerializeField]
    private AudioClip gameOverClip, jumpClip, pipeHitClip;

    private AudioSource audioSource;

    private bool didJump;
    void Awake()
    {    
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
        anim = GetComponent<Animator>();
        extraJumpValue = 2;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isPipe == true)
        {
            extraJump = extraJumpValue;
        }

        if (isAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
            {
                extraJump--;
                rb.velocity = new Vector3(rb.velocity.x, bounceForce);
                anim.SetBool("IsJumping", true);
            }

            if (didJump == true && extraJump > 0)
            {            
                extraJump--;
                rb.velocity = new Vector3(rb.velocity.x, bounceForce);
                anim.SetBool("IsJumping", true);
                didJump = false;
                audioSource.clip = jumpClip;
                audioSource.Play();
            }
        }
    }

    void FixedUpdate()
    {
        isPipe = Physics2D.OverlapBox(pipeCheck.position, new Vector2(0.15f, 0.01f), 0 , whatIsPipe);
    }

    public void _JumpButton()
    {
        didJump = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            anim.SetTrigger("Die");
            isAlive = false;

            if (GamePlayController.instance != null)
            {
                GamePlayController.instance._ShowGameOverPanel();
            }

            audioSource.clip = gameOverClip;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Pipe")
        {
            anim.SetBool("IsJumping", false);       
        }
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("IsJumping", false);
        }


        if (collision.gameObject.tag == "Plus")
        {
            anim.SetBool("IsJumping", false);
            var plus = collision.collider.GetComponent<Plus>();
            plus?._Lost();

            if (GamePlayController.instance != null)
            {
                GamePlayController.instance._SetScore();
            }

            audioSource.clip = pipeHitClip;
            audioSource.Play();
        }
    }
}
