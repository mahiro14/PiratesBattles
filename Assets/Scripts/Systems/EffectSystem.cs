using UnityEngine;

public class EffectSystem
{
    GameState gameState;
    GameEvent gameEvent;
    public EffectSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;
    }

    public void OnUpdate()
    {
        
    }

    void EnemyDefeatEffect(EnemyBaseComponent enemyComp)
    {

    }

    void PlayerDefeatEffect()
    {
        
    }

}
