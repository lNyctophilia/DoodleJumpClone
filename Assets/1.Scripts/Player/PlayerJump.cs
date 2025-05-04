using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public static PlayerJump Instance;
    Rigidbody2D rb;
    public bool falling;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    public void Jump(float JumpForce = 2f)
    {
        rb.velocity = Vector2.up * JumpForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block" && LevelManager.Instance.isStart)
        {
            Jump();
            Audio.Instance.PlayVoice("Jump");
        }
    }
    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            falling = true;
        }
        else falling = false;
    }
}
