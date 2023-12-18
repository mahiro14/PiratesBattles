using UnityEngine;

public class DamageTextSystem
{
    GameState gameState;
    GameEvent gameEvent;

    DamageTextPool damageTextPool;
    DamageTextComponent damageTextComp;
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
        TextsAction();
    }

    void TextsAction()
    {
        int count = gameState.damageTexts.Count;
        if (count == 0) return;
        for (int i=count-1 ; i>=0 ; --i)
        {
            damageTextComp = gameState.damageTexts[i];
            damageTextComp.transform.LookAt(Camera.main.transform);
            damageTextComp.timer += Time.deltaTime;
            if (damageTextComp.timer > damageTextComp.removeTime)
            {
                damageTextComp.timer = 0;
                gameEvent.onRemoveText(damageTextComp);
            }
        }
    }

    void GeneText(GameObject attacker, GameObject target)
    {
        GameObject damageText = damageTextPool.OnShowText(gameState.prefabDamageText, target);
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

}
