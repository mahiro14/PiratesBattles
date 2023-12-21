using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScreen : BaseScreen
{
    GameState gameState;
    GameEvent gameEvent;
    [SerializeField] Button titleButton;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    PlayerComponent playerComp;
    public override void Init(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.showResult += OnShow;
        gameEvent.showTitle += OnHide;

        titleButton.onClick.AddListener(ShowTitleScreen);
        this.gameObject.SetActive(false);
    }

    void ShowTitleScreen()
    {
        gameEvent.resetGame?.Invoke();
        gameEvent.showTitle?.Invoke();
    }

    public override void OnShow()
    {
        base.OnShow();
        Debug.Log("Open Result Screen");
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        gameState.gameStatus = GameStatus.Result;
        scoreText.SetText(playerComp.score.ToString());
        SetTime(gameState.gameTimer);
    }

    private void SetTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        this.timeText.SetText(timeText);
    }
}
