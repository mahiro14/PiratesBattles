using UnityEngine;

public class MinimapSystem
{
    GameState gameState;
    GameEvent gameEvent;
    public MinimapSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;
    }

    public void OnUpdate()
    {
        PlayerMarkLookCamera();
    }

    private void PlayerMarkLookCamera()
    {
        gameState.playerCanvas.transform.LookAt(gameState.minimapCamera.transform);
    }
}
