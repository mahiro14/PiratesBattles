using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextPool
{
    GameState gameState;
    GameEvent gameEvent;
    private Dictionary<int, List<GameObject>> pool = new Dictionary<int, List<GameObject>>();

    public DamageTextPool(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.removeText += RemoveText;
    }

    private void RemoveText(DamageTextComponent damageTextComp)
    {
        damageTextComp.gameObject.SetActive(false);
        gameState.damageTexts.Remove(damageTextComp);
    }

    public GameObject ShowText(GameObject textPrefab, GameObject target)
    {
        Vector3 genePos = target.transform.position;
        int hash = textPrefab.GetHashCode();
        if (pool.ContainsKey(hash))
        {
            List<GameObject> targetPool = pool[hash];
            int count = targetPool.Count;
            for(int j=0 ; j<count ; j++)
            {
                if (targetPool[j].activeSelf == false)
                {
                    targetPool[j].SetActive(true);
                    targetPool[j].transform.position = genePos;
                    return targetPool[j];
                }
            }
            GameObject damageText = GameObject.Instantiate(targetPool[0], genePos, Quaternion.identity, gameState.parentDamageText);
            targetPool.Add(damageText);
            damageText.SetActive(true);
            return damageText;
        }

        GameObject damageText2 = GameObject.Instantiate(textPrefab, genePos, Quaternion.identity, gameState.parentDamageText);
        List<GameObject> poolList = new List<GameObject>();
        poolList.Add(damageText2);
        pool.Add(hash, poolList);
        damageText2.SetActive(true);
        return damageText2;
    }
}