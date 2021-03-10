using UnityEngine;

public class Frog : MonoBehaviour
{
    public void die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
       //GetComponent<Collider2D>().enabled = false;
    }

    public void respawn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
       //GetComponent<Collider2D>().enabled = true;
    }
}
