using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : BaseScreen
{
    GameState gameState;
    GameEvent gameEvent;
    [SerializeField] Button startButton;
    [SerializeField] Button exitGameButton;
    public override void Init(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.showTitle += OnShow;
        gameEvent.startGame += OnHide;

        startButton.onClick.AddListener(StartGame);
        exitGameButton.onClick.AddListener(ExitGame);
        this.gameObject.SetActive(false);
    }

    void StartGame()
    {
        gameState.gameStatus = GameStatus.IsPlaying;
        gameEvent.startGame?.Invoke();
    }

    void ExitGame()
    {
        gameEvent.exitGame?.Invoke();
    }

    public override void OnShow()
    {
        base.OnShow();
        Debug.Log("Open Title Screen");
        gameState.gameStatus = GameStatus.Ready;
    }
}
