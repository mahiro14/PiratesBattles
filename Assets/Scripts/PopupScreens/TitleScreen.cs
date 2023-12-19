using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : BaseScreen
{
    GameState gameState;
    GameEvent gameEvent;
    [SerializeField] Button startButton;
    public override void Init(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.showTitle += OnShow;
        gameEvent.startGame += OnHide;

        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        gameState.gameStatus = GameStatus.IsPlaying;
        gameEvent.startGame?.Invoke();
    }

    public override void OnShow()
    {
        base.OnShow();
        gameState.gameStatus = GameStatus.Ready;
    }
}
