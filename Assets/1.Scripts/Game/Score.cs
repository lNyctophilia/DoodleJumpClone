using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public Text scoreText, scoreTable, highScoreTable;
    public int scoreValue, highScore;
    Transform player;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        scoreText.text = "0";
        player = LevelManager.Instance.Player.transform;
    }
    private void Update()
    {
        SetScore();
        CheckHighScore();
    }
    public void ResetScore()
    {
        scoreValue = 0;
        scoreText.text = scoreValue.ToString();
    }
    void SetScore()
    {
        if(scoreValue < ((int)(player.position.y * 10)))
            scoreValue = ((int)(player.position.y * 10));

        scoreText.text = scoreValue.ToString();
    }
    void CheckHighScore()
    {
        if(scoreValue > highScore)
        {
            highScore = scoreValue;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
    }
    public void SetScoreTable()
    {
        scoreTable.text = scoreValue.ToString();
        highScoreTable.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}
