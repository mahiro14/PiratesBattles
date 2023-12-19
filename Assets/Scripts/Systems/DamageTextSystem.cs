using UnityEngine;

public class DamageTextSystem
{
    GameState gameState;
    GameEvent gameEvent;

    DamageTextPool damageTextPool;
    public DamageTextSystem(GameState _gameState, GameEvent _gameEvent)
    {
        gameState = _gameState;
        gameEvent = _gameEvent;

        gameEvent.startGame += Init;
    }

    void Init()
    {
        damageTextPool = new DamageTextPool(gameState, gameEvent);
        gameEvent.geneText += GeneText;
    }

    public void OnUpdate()
    {
        if (gameState.gameStatus != GameStatus.IsPlaying) return;
        UpdateTexts();
    }

    void UpdateTexts()
    {
        int count = gameState.damageTexts.Count;
        if (count == 0) return;
        for (int i=count-1 ; i>=0 ; --i)
        {
            DamageTextComponent damageTextComp = gameState.damageTexts[i];
            if (damageTextComp == null) continue;
            damageTextComp.transform.LookAt(gameState.mainCamera.transform);

            damageTextComp.timer += Time.deltaTime;
            if (damageTextComp.timer < damageTextComp.removeTime) continue;
            RemoveText(damageTextComp);
        }
    }

    void GeneText(GameObject attacker, GameObject target)
    {
        GameObject damageText = damageTextPool.ShowText(gameState.prefabDamageText, target);
        DamageTextComponent damageTextComp = damageText.GetComponent<DamageTextComponent>();
        if (attacker.CompareTag("Player"))
        {
            PlayerComponent playerComp = attacker.GetComponent<PlayerComponent>();
            damageTextComp.damage = playerComp.attack;
            damageTextComp.damageText.color = Color.white;
        }
        else if (attacker.CompareTag("Enemy"))
        {
            EnemyBaseComponent enemyComp = attacker.GetComponent<EnemyBaseComponent>();
            damageTextComp.damage = enemyComp.attack;
            damageTextComp.damageText.color = Color.red;
        }
        else return;

        damageTextComp.damageText.SetText(damageTextComp.damage.ToString());
        gameState.damageTexts.Add(damageTextComp);
    }

    void RemoveText(DamageTextComponent damageTextComp)
    {
        damageTextComp.timer = 0;
        gameEvent.removeText(damageTextComp);
    }
}
