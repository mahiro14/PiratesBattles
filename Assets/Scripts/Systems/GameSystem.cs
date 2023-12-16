using UnityEngine;

public class GameSystem
{
    GameState gameState;
    GameEvent gameEvent;
    public GameSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;
    }

    public void OnUpdate()
    {
        CountTimer();
    }

    void CountTimer()
    {
        gameState.gameTimer += Time.deltaTime;
        gameState.enemySpawnTimer += Time.deltaTime;
    }
}
