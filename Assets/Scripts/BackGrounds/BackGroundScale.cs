using UnityEngine;

public class BackGroundScale : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>(); // khai bao chieu cao cua anh
        Vector3 tempScale = transform.localScale;// khai bao scale cua anh

        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f;// 10
        float worldWidth = worldHeight * Screen.width / Screen.height;//10 * 203//339

        tempScale.y = worldHeight / height; // anh cham vao bien camera se dung
        tempScale.x = worldWidth / width;

        transform.localScale = tempScale;
    }
}
