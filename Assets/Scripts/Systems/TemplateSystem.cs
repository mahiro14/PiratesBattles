using UnityEngine;

public class TemplateSystem
{
    GameState gameState;
    GameEvent gameEvent;
    public TemplateSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;
    }

    public void OnUpdate()
    {
        if ( gameState.gameStatus != GameStatus.IsPlaying) return;
    }
}
