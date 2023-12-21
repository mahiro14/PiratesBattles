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

    private void Init()
    {
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        pool.Clear();
    }

    private void OnRemoveEnemy(EnemyBaseComponent enemyComp)
    {
        enemyComp.gameObject.SetActive(false);
        gameState.activeEnemies.Remove(enemyComp);
        playerComp.score += enemyComp.score;
    }

    public void OnSpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 genePos = playerComp.transform.position + RandomPos();
        int hash = enemyPrefab.GetHashCode();
        if (pool.ContainsKey(hash))
        {
            List<GameObject> targetPool = pool[hash];
            bool isSpawned = false;
            int count = targetPool.Count;
            if (count == 0) return;
            for (int i=count-1 ; i>=0 ; --i)
            {
                if (!targetPool[i].activeSelf)
                {
                    targetPool[i].SetActive(true);
                    targetPool[i].transform.position = genePos;
                    ResetEnemy(targetPool[i]);
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
    private Vector3 RandomPos()
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

    private void ResetEnemy(GameObject enemy)
    {
        // 初期値セット
        enemyComp = enemy.GetComponent<EnemyBaseComponent>();
        enemyComp.hp = enemyComp.maxHp;
        enemyComp.hpBar.maxValue = enemyComp.maxHp;
        enemyComp.hpBar.value = enemyComp.maxHp;
        enemyComp.attackTimer = 0;
        enemyComp.attackBar.maxValue = enemyComp.coolTime;
        enemyComp.attackBar.value = 0;

        // Enemyリストに追加
        gameState.enemies.Add(enemyComp);
        gameState.activeEnemies.Add(enemyComp);
    }
}