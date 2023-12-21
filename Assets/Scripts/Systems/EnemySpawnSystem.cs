using UnityEngine;

public class EnemySpawnSystem
{
    GameState gameState;
    GameEvent gameEvent;
    EnemyBaseComponent enemyComp;
    PlayerComponent playerComp;

    EnemyPool enemyPool;
    Vector3 pPos;
    public EnemySpawnSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;
        enemyPool = new EnemyPool(gameState, gameEvent);

        gameEvent.startGame += Init;
        gameEvent.resetGame += ResetGame;
    }

    void Init()
    {
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        enemyComp = gameState.enemy.GetComponent<EnemyBaseComponent>();
    }

    public void OnUpdate()
    {
        if (gameState.gameStatus != GameStatus.IsPlaying) return;
        EnemySpawnAction();
    }

    private void ResetGame()
    {
        gameState.enemies.Clear();
        int count = gameState.parentEnemies.transform.childCount;
        if (count == 0) return;
        for (int i=count-1 ; i>=0 ; --i)
        {
            Transform enemy = gameState.parentEnemies.transform.GetChild(i);
            GameObject.Destroy(enemy.gameObject);
        }
    }

    void EnemySpawnAction()
    {
        pPos = playerComp.transform.position;
        if ( gameState.enemySpawnTimer > gameState.spawnCoolTime )
        {
            if (gameState.enemyCountLimit <= gameState.activeEnemies.Count) return;
            EnemyGenerate();
            gameState.enemySpawnTimer = 0;
        }
    }

    void EnemyGenerate()
    {
        int randNum = Random.Range(0, gameState.enemyPrefab.Count);
        switch(randNum)
        {
            case 0:
                GenerateRedSlime();
                break;
            case 1:
                GenerateBlueTurtle();
                break;
            default:
                break;
        }
    }

    void GenerateRedSlime()
    {
        enemyPool.OnSpawnEnemy(gameState.enemyPrefab[0]);
    }

    void GenerateBlueTurtle()
    {
        enemyPool.OnSpawnEnemy(gameState.enemyPrefab[1]);
    }

}
