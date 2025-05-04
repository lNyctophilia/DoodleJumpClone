using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject[] UI;
    public float Sure = 0.8f;
    void Awake()
    {
        Instance = this;
    }
    public void CloseUI(string Menu)
    {
        GameObject UIobject = UI[0];
        foreach (GameObject gameObject in UI)
        {
            if (gameObject.name == Menu)
            {
                UIobject = gameObject;
                break;
            }
        }
        UIobject.SetActive(false);
    }
    public void OpenUI(string Menu)
    {
        GameObject UIobject = UI[0];
        foreach (GameObject gameObject in UI)
        {
            if (gameObject.name == Menu)
            {
                UIobject = gameObject;
                break;
            }
        }
        UIobject.SetActive(true);
    }
}