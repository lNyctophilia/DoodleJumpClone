using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAnim : MonoBehaviour
{
    Vector3 startPos;
    public float Distance = 100, Sure = 0.5f;
    public LeanTweenType easeType;
    bool Stop;
    private void Start()
    {
        startPos = transform.localPosition;
        Jump();
    }
    void Jump()
    {
        if (Stop)  return;
        Audio.Instance.PlayVoice("Jump");
        LeanTween.moveLocalY(gameObject, startPos.y + Distance, Sure).setEase(easeType).setOnComplete(() =>
        {
            LeanTween.moveLocalY(gameObject, startPos.y, Sure -0.1f).setEase(easeType).setOnComplete(Jump);
        });
    }
    private void OnEnable()
    {
        Stop = false;
        Jump();
    }
    private void OnDisable()
    {
        Stop = true;
    }
}
