using UnityEngine;

public class EffectSystem
{
    GameState gameState;
    GameEvent gameEvent;

    DamageEffectPool damageEffectPool;
    DamageEffectComponent damageEffectComp;
    public EffectSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
        gameEvent.resetGame += ResetGame;
        gameEvent.geneEffect += GeneEffect;
    }

    private void Init()
    {
        // damageEffectPool = new DamageEffectPool(gameState, gameEvent);
    }

    public void OnUpdate()
    {

    }

    private void ResetGame()
    {
        int count = gameState.parentEffects.transform.childCount;
        if (count == 0) return;
        for (int i=count-1 ; i>=0 ; --i)
        {
            Transform damageEffect = gameState.parentEffects.transform.GetChild(i);
            GameObject.Destroy(damageEffect.gameObject);
        }
    }

    // void EffectAction()
    // {
    //     int count = gameState.damageEffects.Count;
    //     if (count == 0) return;
    //     for (int i=count-1 ; i>=0 ; --i)
    //     {
    //         damageEffectComp = gameState.damageEffects[i];
    //         damageEffectComp.timer += Time.deltaTime;
    //         if (damageEffectComp.timer > damageEffectComp.removeTime)
    //         {
    //             damageEffectComp.timer = 0;
    //             gameEvent.removeEffect(damageEffectComp);
    //         }
    //     }
    // }

    private void GeneEffect(GameObject target)
    {
        Debug.Log("GeneEffect");
        GameObject damageEffect = GameObject.Instantiate(gameState.damageEffectPrefab, target.transform.position, Quaternion.identity, gameState.parentEffects);
    }
}
