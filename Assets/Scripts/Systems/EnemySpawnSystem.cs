using UnityEngine;

public class EnemySpawnSystem
{
    GameState gameState;
    GameEvent gameEvent;
    EnemyBaseComponent enemyComp;
    PlayerComponent playerComp;
    Vector3 pPos;
    public EnemySpawnSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        playerComp = gameState.player.GetComponent<PlayerComponent>();
        enemyComp = gameState.enemy.GetComponent<EnemyBaseComponent>();
    }

    public void OnUpdate()
    {
        pPos = playerComp.transform.position;
        if ( gameState.enemySpawnTimer > gameState.spawnCoolTime )
        {
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
        GameObject redSlime = GameObject.Instantiate(gameState.enemyPrefab[0], pPos + RandomPos(), Quaternion.identity);
        gameState.enemies.Add(redSlime);
    }

    void GenerateBlueTurtle()
    {
        GameObject blueTurtle = GameObject.Instantiate(gameState.enemyPrefab[1], pPos + RandomPos(), Quaternion.identity);
        gameState.enemy = blueTurtle;
    }

    Vector3 RandomPos()
    {
        float hor = 0;
        float ver = 0;
        float rnd = Random.Range(1,4);
        switch (rnd)
        {
            case 1:
                hor = 30 + Random.Range(1,6);
                break;
            case 2:
                hor = -30 - Random.Range(1,6);
                break;
            case 3:
                hor = Random.Range(-30,30);
                break;
        }

        if (rnd == 3) rnd = Random.Range(1,3);
        else rnd = Random.Range(1,4);

        switch (rnd)
        {
            case 1:
                ver = 30 + Random.Range(1,6);
                break;
            case 2:
                ver = -30 - Random.Range(1,6);
                break;
            case 3:
                ver = Random.Range(-30,30);
                break;
        }
        Vector3 addVec = new Vector3(hor, 0, ver);
        return addVec; 
    }
}
