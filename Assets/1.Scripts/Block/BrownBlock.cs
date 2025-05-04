using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownBlock : MonoBehaviour
{
    Animator anim;
    bool isBreak;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isBreak) return;
            isBreak = true;
            anim.Play("BrownBreak");
            Audio.Instance.PlayVoice("Break");
            LeanTween.moveLocal(gameObject, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - 1f, gameObject.transform.localPosition.z), 0.7f).setOnComplete(() => {
                Destroy(gameObject);
            });
        }
    }
}
