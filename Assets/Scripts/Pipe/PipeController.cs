using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private float speed = 2;


    public SpriteRenderer sR;
    public Sprite S1;
    public Sprite S2;

    private Plus plus;

    void Start()
    {
        obj = gameObject;
        plus = GetComponent<Plus>();
    }

    void Update()
    {
        obj.transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (obj.transform.position.x < -4)
        {
            obj.transform.position += new Vector3(40, 0, 0);
            plus?._Respawn();
            sR.sprite = S1;
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sR.sprite = S2;
        }
    }

}
