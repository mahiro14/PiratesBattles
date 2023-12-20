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
        this.gameObject.SetActive(false);
    }
    public override void OnShow()
    {
        base.OnShow();
        Debug.Log("Open Pause Screen");
        gameState.gameStatus = GameStatus.PauseGame;
    }

    void OnClickBackGameButton()
    {
        gameState.gameStatus = GameStatus.IsPlaying;
        OnHide();
    }
}