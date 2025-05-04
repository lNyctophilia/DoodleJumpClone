using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 startTouchPosition; // Parma��n ba�lang�� pozisyonu
    private Vector2 lastTouchPosition;  // Parma��n bir �nceki pozisyonu
    private float touchSpeed;           // Parma��n s�r�kleme h�z�
    private bool isDragging = false;    // Parma��n s�r�klenip s�r�klenmedi�i kontrol�
    public float speedMultiplier = 0.0015f; // H�z �arpan� (Hareketi yava�latmak i�in)
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Mobil dokunma kontrol�
        if (Input.touchCount > 0) // Mobilde dokunma olaylar�n� kontrol et
        {
            Touch touch = Input.GetTouch(0);

            // Dokunma i�lemi ba�lad���nda
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                lastTouchPosition = touch.position;
                isDragging = true;
            }
            // Parma��n hareketi s�ras�nda
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 currentTouchPosition = touch.position;
                touchSpeed = (currentTouchPosition.x - lastTouchPosition.x) / Time.deltaTime;
                lastTouchPosition = currentTouchPosition;
            }
            // Parma��n kald�r�lmas�
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
                touchSpeed = 0f;
            }
        }
        // Fare kontrol� (PC i�in)
        else if (Input.GetMouseButton(0)) // Fare t�klamas� durumunu kontrol et
        {
            if (!isDragging) // E�er daha �nce s�r�kleme ba�lamad�ysa
            {
                startTouchPosition = Input.mousePosition;
                lastTouchPosition = Input.mousePosition;
                isDragging = true;
            }

            // Fare hareketi s�ras�nda
            Vector2 currentMousePosition = Input.mousePosition;
            touchSpeed = (currentMousePosition.x - lastTouchPosition.x) / Time.deltaTime;
            lastTouchPosition = currentMousePosition;
        }
        // Fare tu�u b�rak�ld���nda
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            touchSpeed = 0f;
        }

        // Karakteri hareket ettir
        MoveCharacter();

        if(touchSpeed > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (touchSpeed < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void MoveCharacter()
    {
        if (!LevelManager.Instance.isStart) return;

        // Hareketi h�zland�rmak ve yava�latmak i�in �arpan kullan
        transform.position += new Vector3(touchSpeed * speedMultiplier * Time.deltaTime, 0, 0);
    }
}
