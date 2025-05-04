using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    GameObject Player;
    BoxCollider2D boxCollider;
    public float screenEdgeBuffer = 0.15f;
    float bottomScreenEdge;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        Player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (Player.transform.localPosition.y > transform.position.y && PlayerJump.Instance.falling)
        {
            boxCollider.enabled = true;
        }
        else boxCollider.enabled = false;

        UpdateScreenEdges();
        if (transform.position.y < bottomScreenEdge)
            Destroy(gameObject);

    }
    void UpdateScreenEdges()
    {
        Vector3 bottomScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        bottomScreenEdge = bottomScreen.y - screenEdgeBuffer;
    }
}
