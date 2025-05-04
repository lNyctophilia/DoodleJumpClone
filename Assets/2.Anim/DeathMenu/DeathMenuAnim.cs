using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuAnim : MonoBehaviour
{
    public static DeathMenuAnim Instance;
    Vector3 startPos;
    public float width, height;
    RectTransform rectTransform;
    void Awake()
    {
        Instance = this;
        width = Screen.width; height = Screen.height;
        startPos = transform.localPosition;
        rectTransform = GetComponent<RectTransform>();
        SetSize(rectTransform, Screen.width, Screen.height);
    }

    void SetSize(RectTransform rectTransform, float width, float height)
    {
        rectTransform.sizeDelta = new Vector2(width, height);
    }
    public void DeathCamera()
    {
        transform.localPosition = new Vector3(startPos.x, startPos.y - Screen.height * 2, startPos.z);
        LeanTween.cancel(gameObject);
        LeanTween.moveLocalY(gameObject, startPos.y, 0.6f).setEaseLinear();
    }
}
