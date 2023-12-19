using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffectPool
{
    GameState gameState;
    GameEvent gameEvent;
    private Dictionary<int, List<GameObject>> pool = new Dictionary<int, List<GameObject>>();

    public DamageEffectPool(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.removeEffect += RemoveEffect;
    }

    private void RemoveEffect(DamageEffectComponent damageEffectComp)
    {
        damageEffectComp.gameObject.SetActive(false);
        gameState.damageEffects.Remove(damageEffectComp);
    }

    public GameObject ShowEffect(GameObject textPrefab, GameObject target)
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
            GameObject damageEffect = GameObject.Instantiate(targetPool[0], genePos, Quaternion.identity, gameState.parentEffects);
            targetPool.Add(damageEffect);
            damageEffect.SetActive(true);
            return damageEffect;
        }

        GameObject damageEffect2 = GameObject.Instantiate(textPrefab, genePos, Quaternion.identity, gameState.parentEffects);
        List<GameObject> poolList = new List<GameObject>();
        poolList.Add(damageEffect2);
        pool.Add(hash, poolList);
        damageEffect2.SetActive(true);
        return damageEffect2;
    }
}