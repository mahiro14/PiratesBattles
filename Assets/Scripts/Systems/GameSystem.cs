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

    private void CountTimer()
    {
        gameState.timer += Time.deltaTime;
    }
}
