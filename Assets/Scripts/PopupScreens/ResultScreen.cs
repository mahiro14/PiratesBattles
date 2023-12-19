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
    PlayerComponent playerComp;
    public override void Init(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.showResult += OnShow;
        gameEvent.showTitle += OnHide;

        playerComp = gameState.player.GetComponent<PlayerComponent>();

        titleButton.onClick.AddListener(ShowTitleScreen);
    }

    void ShowTitleScreen()
    {
        gameEvent.resetGame?.Invoke();
        gameEvent.showTitle?.Invoke();
    }

    public override void OnShow()
    {
        base.OnShow();
        gameState.gameStatus = GameStatus.Result;
        scoreText.SetText(playerComp.score.ToString());
    }
}
