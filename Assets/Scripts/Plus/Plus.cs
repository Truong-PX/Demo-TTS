using UnityEngine;

public class Plus : MonoBehaviour
{
    public void _Lost()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    public void _Respawn()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
