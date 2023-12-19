using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : BaseScreen
{
    GameState gameState;
    GameEvent gameEvent;
    [SerializeField] Button backGameButton;
    public override void Init(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.pauseGame += OnShow;

        backGameButton.onClick.AddListener(OnClickBackGameButton);
    }
    public override void OnShow()
    {
        base.OnShow();
        gameState.gameStatus = GameStatus.PauseGame;
    }

    void OnClickBackGameButton()
    {
        gameState.gameStatus = GameStatus.IsPlaying;
        OnHide();
    }
}