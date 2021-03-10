using UnityEngine;

public class GroundBotton1Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    void Update()
    {
        transform.position = new Vector3(transform.position.x - 1 * Time.deltaTime * speed, 0, 0);
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}
