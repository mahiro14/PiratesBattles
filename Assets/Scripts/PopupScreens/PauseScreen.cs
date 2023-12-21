using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : BaseScreen
{
    GameState gameState;
    GameEvent gameEvent;
    [SerializeField] Button backGameButton;
    [SerializeField] Button titleButton;
    [SerializeField] Button exitGameButton;

    public override void Init(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.pauseGame += OnShow;

        backGameButton.onClick.AddListener(OnClickBackGameButton);
        exitGameButton.onClick.AddListener(ExitGame);
        titleButton.onClick.AddListener(ShowTitleScreen);
        this.gameObject.SetActive(false);
    }
    public override void OnShow()
    {
        base.OnShow();
        Debug.Log("Open Pause Screen");
        gameState.gameStatus = GameStatus.PauseGame;
    }

    private void OnClickBackGameButton()
    {
        gameState.gameStatus = GameStatus.IsPlaying;
        OnHide();
    }

    private void ExitGame()
    {
        gameEvent.exitGame?.Invoke();
    }

    private void ShowTitleScreen()
    {
        base.OnHide();
        gameEvent.resetGame?.Invoke();
        gameEvent.showTitle?.Invoke();
    }
}