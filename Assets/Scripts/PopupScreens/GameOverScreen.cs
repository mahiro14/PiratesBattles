using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : BaseScreen
{
    GameState gameState;
    GameEvent gameEvent;
    [SerializeField] Button resultButton;
    public override void Init(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.gameOver += OnShow;
        gameEvent.showResult += OnHide;

        resultButton.onClick.AddListener(ShowResultScreen);
    }
    
    void ShowResultScreen()
    {
        gameEvent.showResult?.Invoke();
    }
    public override void OnShow()
    {
        base.OnShow();
        gameState.gameStatus = GameStatus.GameOver;
    }
}
