using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPool
{
    GameState gameState;
    GameEvent gameEvent;
    private Dictionary<int, List<GameObject>> pool = new Dictionary<int, List<GameObject>>();

    PlayerComponent playerComp;
    CannonBallComponent cannonComp;

    public CannonPool(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.onRemoveCannon += OnRemoveCannon;
        gameEvent.startGame += Init;
    }

    void Init()
    {
        playerComp = gameState.player.GetComponent<PlayerComponent>();
        pool.Clear();
    }

    void OnRemoveCannon(CannonBallComponent cannonComp)
    {
        cannonComp.gameObject.SetActive(false);
        cannonComp.rig.velocity = Vector3.zero;
        gameState.cannonBalls.Remove(cannonComp);
    }

    public GameObject OnGeneCannon(GameObject cannonPrefab)
    {
        Vector3 genePos = gameState.cannonMuzzle.transform.position;
        int hash = cannonPrefab.GetHashCode();
        if (pool.ContainsKey(hash))
        {
            List<GameObject> targetPool = pool[hash];
            bool isSpawned = false;
            int count = targetPool.Count;
            if (count == 0) return null;
            for (int i=count-1 ; i>=0 ; --i)
            {
                if (!targetPool[i].activeSelf)
                {
                    targetPool[i].transform.position = genePos;
                    isSpawned = true;
                    return targetPool[i];
                }
            }
            if (!isSpawned)
            {
                GameObject cannon = GameObject.Instantiate(cannonPrefab, genePos, Quaternion.identity, gameState.cannonBallParent);
                targetPool.Add(cannon);
                return cannon;
            }
        }
        else
        {
            GameObject cannon = GameObject.Instantiate(cannonPrefab, genePos, Quaternion.identity, gameState.cannonBallParent);
            cannonComp = cannon.GetComponent<CannonBallComponent>();
            List<GameObject> poolList = new List<GameObject> { cannon };
            pool.Add(hash, poolList);
            return cannon;
        }
        return null;
    }

    // 画面外の近い位置を生成
    Vector3 RandomPos()
    {
        float hor = Mathf.Clamp(Random.Range(-36, 36), -30, 30);
        float ver = Mathf.Clamp(Random.Range(-36, 36), -30, 30);
        Vector3 addVec = new Vector3(hor, 0, ver);
        return addVec; 
    }
}