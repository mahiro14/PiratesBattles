using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool
{
    GameState gameState;
    GameEvent gameEvent;
    private Dictionary<int, List<GameObject>> pool = new Dictionary<int, List<GameObject>>();

    PlayerComponent playerComp;
    EnemyBaseComponent enemyComp;

    public EnemyPool(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.onRemoveEnemy += OnRemoveEnemy;
        gameEvent.startGame += Init;
    }

    void Init()
    {
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        pool.Clear();
    }

    void OnRemoveEnemy(EnemyBaseComponent enemyComp)
    {
        enemyComp.gameObject.SetActive(false);
        // gameState.enemies.Remove(enemyComp);
        playerComp.xp += enemyComp.dropXp;
    }

    public void OnSpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 genePos = playerComp.transform.position + RandomPos();
        int hash = enemyPrefab.GetHashCode();
        if (pool.ContainsKey(hash))
        {
            List<GameObject> targetPool = pool[hash];
            bool isSpawned = false;
            foreach (var enemy in targetPool)
            {
                if (!enemy.activeSelf)
                {
                    enemy.SetActive(true);
                    enemy.transform.position = genePos;
                    ResetEnemy(enemy);
                    isSpawned = true;
                    break;
                }
            }
            if (!isSpawned)
            {
                GameObject enemy = GameObject.Instantiate(enemyPrefab, genePos, Quaternion.identity, gameState.parentEnemies);
                ResetEnemy(enemy);
                targetPool.Add(enemy);
                enemy.SetActive(true);
            }
        }
        else
        {
            GameObject enemy = GameObject.Instantiate(enemyPrefab, genePos, Quaternion.identity, gameState.parentEnemies);
            ResetEnemy(enemy);
            List<GameObject> poolList = new List<GameObject> { enemy };
            pool.Add(hash, poolList);
            enemy.SetActive(true);
        }
    }

    // 画面外の近い位置を生成
    Vector3 RandomPos()
    {
        float hor = Mathf.Clamp(Random.Range(-36, 36), -30, 30);
        float ver = Mathf.Clamp(Random.Range(-36, 36), -30, 30);
        Vector3 addVec = new Vector3(hor, 0, ver);
        return addVec; 
    }

    void ResetEnemy(GameObject enemy)
    {
        // 初期値セット
        enemyComp = enemy.GetComponent<EnemyBaseComponent>();
        enemyComp.hp = enemyComp.maxHp;
        enemyComp.hpBar.maxValue = enemyComp.maxHp;
        enemyComp.hpBar.value = enemyComp.maxHp;

        // Enemyリストに追加
        gameState.enemies.Add(enemyComp);
    }
}