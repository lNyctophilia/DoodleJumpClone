using UnityEngine;

public class Portal : MonoBehaviour
{
    public float screenEdgeBuffer = -0.1f; // Ekran kenar�ndaki tolerans mesafesi
    public string playerTag = "Player"; // Karakterin tag'i

    private float leftScreenEdge;  // Ekran�n sol s�n�r�
    private float rightScreenEdge; // Ekran�n sa� s�n�r�

    void Start()
    {
        // Ekran�n sol ve sa� s�n�rlar�n� hesapla (d�nya koordinatlar�nda)
        UpdateScreenEdges();
    }

    void Update()
    {
        // Ekran s�n�rlar�n� her frame'de g�ncelle
        UpdateScreenEdges();

        // Karakterin d�nyadaki pozisyonunu al
        GameObject player = GameObject.FindWithTag(playerTag);
        if (player == null) return;

        Vector3 playerPos = player.transform.position;

        // E�er karakter ekran�n sol taraf�na ��kt�ysa
        if (playerPos.x < leftScreenEdge)
        {
            // Karakteri ekran�n sa� taraf�na ���nla
            player.transform.position = new Vector3(rightScreenEdge, playerPos.y, playerPos.z);
        }
        // E�er karakter ekran�n sa� taraf�na ��kt�ysa
        else if (playerPos.x > rightScreenEdge)
        {
            // Karakteri ekran�n sol taraf�na ���nla
            player.transform.position = new Vector3(leftScreenEdge, playerPos.y, playerPos.z);
        }
    }

    // Ekran s�n�rlar�n� g�ncellemek i�in yard�mc� fonksiyon
    void UpdateScreenEdges()
    {
        // Ekran�n sa� ve sol kenarlar�n� d�nya koordinatlar�na �evir
        Vector3 leftScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 rightScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane));

        // Ekran kenarlar�
        leftScreenEdge = leftScreen.x + screenEdgeBuffer;
        rightScreenEdge = rightScreen.x - screenEdgeBuffer;
    }
}
