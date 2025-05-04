using UnityEngine;

public class Portal : MonoBehaviour
{
    public float screenEdgeBuffer = -0.1f; // Ekran kenarýndaki tolerans mesafesi
    public string playerTag = "Player"; // Karakterin tag'i

    private float leftScreenEdge;  // Ekranýn sol sýnýrý
    private float rightScreenEdge; // Ekranýn sað sýnýrý

    void Start()
    {
        // Ekranýn sol ve sað sýnýrlarýný hesapla (dünya koordinatlarýnda)
        UpdateScreenEdges();
    }

    void Update()
    {
        // Ekran sýnýrlarýný her frame'de güncelle
        UpdateScreenEdges();

        // Karakterin dünyadaki pozisyonunu al
        GameObject player = GameObject.FindWithTag(playerTag);
        if (player == null) return;

        Vector3 playerPos = player.transform.position;

        // Eðer karakter ekranýn sol tarafýna çýktýysa
        if (playerPos.x < leftScreenEdge)
        {
            // Karakteri ekranýn sað tarafýna ýþýnla
            player.transform.position = new Vector3(rightScreenEdge, playerPos.y, playerPos.z);
        }
        // Eðer karakter ekranýn sað tarafýna çýktýysa
        else if (playerPos.x > rightScreenEdge)
        {
            // Karakteri ekranýn sol tarafýna ýþýnla
            player.transform.position = new Vector3(leftScreenEdge, playerPos.y, playerPos.z);
        }
    }

    // Ekran sýnýrlarýný güncellemek için yardýmcý fonksiyon
    void UpdateScreenEdges()
    {
        // Ekranýn sað ve sol kenarlarýný dünya koordinatlarýna çevir
        Vector3 leftScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 rightScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane));

        // Ekran kenarlarý
        leftScreenEdge = leftScreen.x + screenEdgeBuffer;
        rightScreenEdge = rightScreen.x - screenEdgeBuffer;
    }
}
