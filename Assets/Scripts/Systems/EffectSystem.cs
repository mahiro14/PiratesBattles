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
    }

    void Init()
    {
        damageEffectPool = new DamageEffectPool(gameState, gameEvent);
        gameEvent.geneEffect += GeneEffect;
    }

    public void OnUpdate()
    {
        EffectAction();
    }

    void EffectAction()
    {
        int count = gameState.damageEffects.Count;
        if (count == 0) return;
        for (int i=count-1 ; i>=0 ; --i)
        {
            damageEffectComp = gameState.damageEffects[i];
            damageEffectComp.timer += Time.deltaTime;
            if (damageEffectComp.timer > damageEffectComp.removeTime)
            {
                damageEffectComp.timer = 0;
                gameEvent.onRemoveEffect(damageEffectComp);
            }
        }
    }

    void GeneEffect(GameObject target)
    {
        GameObject damageEffect = damageEffectPool.OnShowEffect(gameState.damageEffectPrefab, target);
        DamageEffectComponent damageEffectComp = damageEffect.GetComponent<DamageEffectComponent>();
        damageEffectComp.particleSystem.Play();
        gameState.damageEffects.Add(damageEffectComp);
    }

}
