using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 startTouchPosition; // Parmaðýn baþlangýç pozisyonu
    private Vector2 lastTouchPosition;  // Parmaðýn bir önceki pozisyonu
    private float touchSpeed;           // Parmaðýn sürükleme hýzý
    private bool isDragging = false;    // Parmaðýn sürüklenip sürüklenmediði kontrolü
    public float speedMultiplier = 0.0015f; // Hýz çarpaný (Hareketi yavaþlatmak için)
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Mobil dokunma kontrolü
        if (Input.touchCount > 0) // Mobilde dokunma olaylarýný kontrol et
        {
            Touch touch = Input.GetTouch(0);

            // Dokunma iþlemi baþladýðýnda
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                lastTouchPosition = touch.position;
                isDragging = true;
            }
            // Parmaðýn hareketi sýrasýnda
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 currentTouchPosition = touch.position;
                touchSpeed = (currentTouchPosition.x - lastTouchPosition.x) / Time.deltaTime;
                lastTouchPosition = currentTouchPosition;
            }
            // Parmaðýn kaldýrýlmasý
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
                touchSpeed = 0f;
            }
        }
        // Fare kontrolü (PC için)
        else if (Input.GetMouseButton(0)) // Fare týklamasý durumunu kontrol et
        {
            if (!isDragging) // Eðer daha önce sürükleme baþlamadýysa
            {
                startTouchPosition = Input.mousePosition;
                lastTouchPosition = Input.mousePosition;
                isDragging = true;
            }

            // Fare hareketi sýrasýnda
            Vector2 currentMousePosition = Input.mousePosition;
            touchSpeed = (currentMousePosition.x - lastTouchPosition.x) / Time.deltaTime;
            lastTouchPosition = currentMousePosition;
        }
        // Fare tuþu býrakýldýðýnda
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

        // Hareketi hýzlandýrmak ve yavaþlatmak için çarpan kullan
        transform.position += new Vector3(touchSpeed * speedMultiplier * Time.deltaTime, 0, 0);
    }
}
