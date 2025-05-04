using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject Player;
    public bool isStart;
    Vector3 playerStartPos;
    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        QualitySettings.SetQualityLevel(1);
        playerStartPos = Player.transform.position;
        Player.SetActive(false);
    }
    public void StartGame()
    {
        isStart = true;
        Player.SetActive(true);
        Transition.Instance.Flash();
        PlayerJump.Instance.Jump(4f);
        Player.transform.position = playerStartPos;
        SetCamera.Instance.ResetCamera();
        Spawner.Instance.DestroyPlatforms();
        Score.Instance.ResetScore();
    }
    public void StopGame()
    {
        if (!isStart) return;
        isStart = false;
        UIManager.Instance.OpenUI("DeathMenu");
        SetCamera.Instance.DeathCamera();
        DeathMenuAnim.Instance.DeathCamera();
        Audio.Instance.PlayVoice("Fall");
        Score.Instance.SetScoreTable();
    }
    public void goMenu()
    {
        Player.SetActive(false);
        Transition.Instance.Flash();
        UIManager.Instance.CloseUI("GameMenu");
        UIManager.Instance.CloseUI("DeathMenu");
        UIManager.Instance.OpenUI("MainMenu");
        SetCamera.Instance.ResetCamera();
        Spawner.Instance.DestroyPlatforms();
        Score.Instance.ResetScore();
    }
}
