using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Button button;
    Vector3 buttonScale;
    public bool isMute = false;

    void Start()
    {
        button = GetComponent<Button>();
        buttonScale = button.GetComponent<RectTransform>().localScale;
    }
    public void OnPointerDown(PointerEventData eventData) => Pressed();
    public void OnPointerUp(PointerEventData eventData) => UnPressed();

    void Pressed()
    {
        if (!isMute)
            Audio.Instance.PlayVoice("Click");
        LeanTween.scale(button.gameObject, buttonScale / 1.2f, 0.05f);
    }
    void UnPressed() => LeanTween.scale(button.gameObject, buttonScale, 0.05f);
}

