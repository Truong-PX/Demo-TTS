using UnityEngine;

public class RandomBackGround : MonoBehaviour
{
    void Start()
    {
        _ShowRandomSprite();
    }
    public void _ShowRandomSprite()
    {
        int index = Random.Range(0, 2);
        int childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            bool shouldShow = index == i;
            child.gameObject.SetActive(shouldShow);
        }
    }
}
