using UnityEngine;

public class Transition : MonoBehaviour
{
    public static Transition Instance;
    public GameObject FadeBlack, FadeWhite;
    public bool isTransition;
    private void Awake()
    {
        Instance = this;
        FadeBlack.SetActive(false);
        FadeWhite.SetActive(false);
    }
    public void FadeOutBlack()
    {
        if (isTransition) return;
        FadeBlack.SetActive(true);
        isTransition = true;
        FadeBlack.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        LeanTween.alpha(FadeBlack, 1, 0.3f).setOnComplete(FadeInBlack);
    }
    void FadeInBlack()
    {
        LeanTween.alpha(FadeBlack, 0, 0.3f).setOnComplete(Finish);
    }
    public void Flash()
    {
        FadeWhite.SetActive(true);
        isTransition = true;
        FadeWhite.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        LeanTween.alpha(FadeWhite, 1, 0.1f);
        LeanTween.alpha(FadeWhite, 0, 0.3f).setOnComplete(Finish).setDelay(0.1f);
    }
    void Finish()
    {
        FadeBlack.SetActive(false);
        FadeWhite.SetActive(false);
        isTransition = false;
    }
}
