using UnityEngine;

public class SetCamera : MonoBehaviour
{
    public static SetCamera Instance;
    Transform Player;
    Vector2 startPos;
    private void Awake()
    {
        Instance = this;
        startPos = transform.position;
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if (transform.position.y < Player.position.y && !PlayerJump.Instance.falling && LevelManager.Instance.isStart)
        {
            transform.localPosition = new Vector2(transform.position.x, Player.position.y);
        }
    }
    public void ResetCamera()
    {
        LeanTween.cancel(gameObject);
        transform.position = startPos;
    }
    public void DeathCamera()
    {
        LeanTween.cancel(gameObject);
        LeanTween.moveY(gameObject, gameObject.transform.localPosition.y - 4f, 0.6f).setEaseLinear();
    }
}
