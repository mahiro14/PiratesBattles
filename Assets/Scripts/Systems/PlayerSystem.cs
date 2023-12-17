using UnityEngine;

public class PlayerSystem
{
    GameState gameState;
    GameEvent gameEvent;
    public PlayerSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
    }

    void Init()
    {
        resetPlayer();
    }
    public void OnUpdate()
    {
        
    }

    void resetPlayer()
    {
        GameObject player = GameObject.Instantiate(gameState.shipPrefab, gameState.basePos, Quaternion.identity);
        Debug.Log("set player");
        gameState.player = player;
    }
}
