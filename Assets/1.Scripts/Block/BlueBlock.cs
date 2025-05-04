using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{
    public float movementSpeed = 0.4f; // Blue platformun hareket h�z�
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

        // Hareket y�n�ne g�re x pozisyonunu de�i�tir
        if (movingRight)
        {
            currentPosition.x += movementSpeed * Time.deltaTime;
            if (currentPosition.x >= rightScreenEdge)
            {
                currentPosition.x = rightScreenEdge;
                movingRight = false; // Sa�a ula�t�, y�n� de�i�tir
            }
        }
        else
        {
            currentPosition.x -= movementSpeed * Time.deltaTime;
            if (currentPosition.x <= leftScreenEdge)
            {
                currentPosition.x = leftScreenEdge;
                movingRight = true; // Sola ula�t�, y�n� de�i�tir
            }
        }

        // Yeni pozisyonu uygula
        transform.position = currentPosition;
    }
}
