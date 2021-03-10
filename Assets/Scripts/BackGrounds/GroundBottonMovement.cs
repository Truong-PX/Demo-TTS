using UnityEngine;

public class GroundBottonMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private float speed = 2;
    void Start()
    {
        obj = gameObject;
    }

    void Update()
    {
        obj.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(obj.transform.position.x < -12)
        {
            obj.transform.position += new Vector3(12, 0, 0);
        }
    }
}
