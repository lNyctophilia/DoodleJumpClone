using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSFX : MonoBehaviour
{
    public static SetSFX Instance;
    public Button SFX_Button;
    public Sprite SFX_ON, SFX_OFF;
    public AudioSource[] voice;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("SFX"))
        {
            PlayerPrefs.SetInt("SFX", 1);
            setSFX();
        }
    }
    public void setSFX()
    {
        if (PlayerPrefs.GetInt("SFX") == 1)
        {
            PlayerPrefs.SetInt("SFX", 0);
            SFX_Button.image.sprite = SFX_OFF;
            for (int i = 0; i < voice.Length; i++)
            {
                voice[i].mute = true;
            }
        }
        else if (PlayerPrefs.GetInt("SFX") == 0)
        {
            PlayerPrefs.SetInt("SFX", 1);
            SFX_Button.image.sprite = SFX_ON;
            for (int i = 0; i < voice.Length; i++)
            {
                voice[i].mute = false;
            }
        }
    }
}
