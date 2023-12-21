using UnityEngine;

public class GameSystem
{
    GameState gameState;
    GameEvent gameEvent;
    PlayerComponent playerComp;
    public GameSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
        gameEvent.exitGame += QuitGame;
    }

    void Init()
    {
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        gameState.pauseButton.onClick.AddListener(ShowPauseScreen);
    }

    public void OnUpdate()
    {
        if ( gameState.gameStatus != GameStatus.IsPlaying) return;
        CountTime(Time.deltaTime);
    }


    private void CountTime(float time)
    {
        gameState.gameTimer += time;
        SetTime(gameState.gameTimer);
        gameState.enemySpawnTimer += Time.deltaTime;
    }

    private void SetTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        gameState.timeText.SetText(timeText);
    }

    void ShowPauseScreen()
    {
        gameEvent.pauseGame?.Invoke();
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
