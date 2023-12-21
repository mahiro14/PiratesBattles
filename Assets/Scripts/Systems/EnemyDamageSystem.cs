using UnityEngine;

public class EnemyDamageSystem
{
    GameState gameState;
    GameEvent gameEvent;
    PlayerComponent playerComp;
    public EnemyDamageSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
        gameEvent.cannonHitEnemy += cannonHitEnemy;
    }

    private void Init()
    {
        playerComp = gameState.player.GetComponent<PlayerComponent>();
    }

    public void OnUpdate()
    {
        
    }

    private void cannonHitEnemy(EnemyBaseComponent enemyComp)
    {
        enemyComp.hp -= playerComp.attack;
        if (enemyComp.hp <= 0)
        {
            // gameEvent.getXp?.Invoke(enemyComp);
            gameEvent.addScore?.Invoke(enemyComp);
            gameEvent.onRemoveEnemy?.Invoke(enemyComp);
        }
        enemyComp.hpBar.value = enemyComp.hp;
    }
}
