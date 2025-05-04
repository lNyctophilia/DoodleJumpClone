using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{
    public float movementSpeed = 0.4f; // Blue platformun hareket hýzý
    public bool movingRight = true;

    public float screenEdgeBuffer = 0.15f;

    float leftScreenEdge, rightScreenEdge;

    void Update()
    {
        UpdateScreenEdges();
        MoveBetweenEdges();
    }
    void UpdateScreenEdges()
    {
        Vector3 leftScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 rightScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane));

        leftScreenEdge = leftScreen.x + screenEdgeBuffer;
        rightScreenEdge = rightScreen.x - screenEdgeBuffer;
    }
    void MoveBetweenEdges()
    {
        // Mevcut pozisyonu al
        Vector3 currentPosition = transform.position;

        // Hareket yönüne göre x pozisyonunu deðiþtir
        if (movingRight)
        {
            currentPosition.x += movementSpeed * Time.deltaTime;
            if (currentPosition.x >= rightScreenEdge)
            {
                currentPosition.x = rightScreenEdge;
                movingRight = false; // Saða ulaþtý, yönü deðiþtir
            }
        }
        else
        {
            currentPosition.x -= movementSpeed * Time.deltaTime;
            if (currentPosition.x <= leftScreenEdge)
            {
                currentPosition.x = leftScreenEdge;
                movingRight = true; // Sola ulaþtý, yönü deðiþtir
            }
        }

        // Yeni pozisyonu uygula
        transform.position = currentPosition;
    }
}
